using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ScottPlot;
using ScottPlot.TickGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interface
{
    public partial class Form2 : Form
    {
        private bool _chartsLoaded;

        public Form2()
        {
            InitializeComponent();
            btntoexcl.Click += ExportExcel_Click;
            btntopdf.Click += ExportPdf_Click;
            backbtnform1.Click += Back_Click;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DrawAllCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawAllCharts()
        {
            DrawProgramChart();
            DrawGenderChart();
            DrawYearGenderChart();
            _chartsLoaded = true;
        }

        private void DrawProgramChart()
        {
            formsPlot1.Plot.Clear();

            var counts = StudentRepository.CountByProgram();
            var positions = new double[counts.Count];
            var labels = new string[counts.Count];

            var index = 0;
            foreach (var item in counts)
            {
                formsPlot1.Plot.Add.Bar(index, item.Value);
                positions[index] = index;
                labels[index] = item.Key;
                index++;
            }

            var ticks = new NumericManual(positions, labels);
            formsPlot1.Plot.Axes.Bottom.TickGenerator = ticks;
            formsPlot1.Plot.Title("Students per Program");
            formsPlot1.Refresh();
        }

        private void DrawGenderChart()
        {
            formsPlot2.Plot.Clear();

            var counts = StudentRepository.CountByGender();
            if (counts.Count == 0)
            {
                formsPlot2.Refresh();
                return;
            }

            var slices = new List<PieSlice>();
            foreach (var item in counts)
            {
                slices.Add(new PieSlice
                {
                    Value = item.Value,
                    Label = $"{item.Key} ({item.Value})",
                    LegendText = $"{item.Key} ({item.Value})"
                });
            }

            var pie = formsPlot2.Plot.Add.Pie(slices);
            pie.DonutFraction = 0.5;
            formsPlot2.Plot.ShowLegend(ScottPlot.Alignment.UpperRight);
            formsPlot2.Plot.Axes.Frameless();
            formsPlot2.Plot.HideGrid();
            formsPlot2.Plot.Title("Gender Split");
            formsPlot2.Refresh();
        }

        private void DrawYearGenderChart()
        {
            formsPlot3.Plot.Clear();

            var counts = StudentRepository.CountByYearLevelAndGender();
            var genders = new[] { "Male", "Female", "Other" };
            var offsets = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                ["Male"] = -0.25,
                ["Female"] = 0,
                ["Other"] = 0.25
            };

            foreach (var gender in genders)
            {
                var bars = new List<Bar>();
                for (var year = 1; year <= 4; year++)
                {
                    counts.TryGetValue((year, gender), out var value);
                    bars.Add(new Bar
                    {
                        Position = year - 1 + offsets[gender],
                        Value = value,
                        Size = 0.25
                    });
                }

                var barPlot = formsPlot3.Plot.Add.Bars(bars);
                barPlot.LegendText = gender;
            }

            var yearTicks = new NumericManual();
            for (var year = 1; year <= 4; year++)
            {
                yearTicks.AddMajor(year - 1, $"Year {year}");
            }
            formsPlot3.Plot.Axes.Bottom.TickGenerator = yearTicks;
            formsPlot3.Plot.ShowLegend(ScottPlot.Alignment.UpperRight);
            formsPlot3.Plot.Title("Year Level by Gender");
            formsPlot3.Refresh();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using var dialog = new SaveFileDialog
                {
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    DefaultExt = "xlsx",
                    FileName = $"Student_Dashboard_{DateTime.Now:yyyyMMdd}.xlsx"
                };

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var programCounts = StudentRepository.CountByProgram();
                var genderCounts = StudentRepository.CountByGender();
                var yearGenderCounts = StudentRepository.CountByYearLevelAndGender();

                using var workbook = new XLWorkbook();

                var programSheet = workbook.Worksheets.Add("By Program");
                programSheet.Cell(1, 1).Value = "Program";
                programSheet.Cell(1, 2).Value = "Count";
                var programRow = 2;
                foreach (var item in programCounts)
                {
                    programSheet.Cell(programRow, 1).Value = item.Key;
                    programSheet.Cell(programRow, 2).Value = item.Value;
                    programRow++;
                }

                var genderSheet = workbook.Worksheets.Add("By Gender");
                genderSheet.Cell(1, 1).Value = "Gender";
                genderSheet.Cell(1, 2).Value = "Count";
                var genderRow = 2;
                foreach (var item in genderCounts)
                {
                    genderSheet.Cell(genderRow, 1).Value = item.Key;
                    genderSheet.Cell(genderRow, 2).Value = item.Value;
                    genderRow++;
                }

                var yearSheet = workbook.Worksheets.Add("By Year and Gender");
                yearSheet.Cell(1, 1).Value = "Year Level";
                yearSheet.Cell(1, 2).Value = "Gender";
                yearSheet.Cell(1, 3).Value = "Count";
                var yearRow = 2;
                foreach (var item in yearGenderCounts.OrderBy(x => x.Key.Year).ThenBy(x => x.Key.Gender))
                {
                    yearSheet.Cell(yearRow, 1).Value = item.Key.Year;
                    yearSheet.Cell(yearRow, 2).Value = item.Key.Gender;
                    yearSheet.Cell(yearRow, 3).Value = item.Value;
                    yearRow++;
                }

                foreach (var sheet in workbook.Worksheets)
                {
                    sheet.Row(1).Style.Font.Bold = true;
                    sheet.Columns().AdjustToContents();
                }

                workbook.SaveAs(dialog.FileName);
                MessageBox.Show("Excel export completed.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_chartsLoaded)
                {
                    DrawAllCharts();
                }

                using var dialog = new SaveFileDialog
                {
                    Filter = "PDF Document (*.pdf)|*.pdf",
                    DefaultExt = "pdf",
                    FileName = $"Student_Dashboard_{DateTime.Now:yyyyMMdd}.pdf"
                };

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                QuestPDF.Settings.License = LicenseType.Community;

                var programBytes = formsPlot1.Plot.GetImageBytes(700, 400, ScottPlot.ImageFormat.Png);
                var genderBytes = formsPlot2.Plot.GetImageBytes(700, 400, ScottPlot.ImageFormat.Png);
                var yearBytes = formsPlot3.Plot.GetImageBytes(700, 400, ScottPlot.ImageFormat.Png);

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(30);
                        page.Header().Column(column =>
                        {
                            column.Item().Text("Student Dashboard").FontSize(20).SemiBold();
                            column.Item().Text($"Generated: {DateTime.Now:yyyy-MM-dd}");
                        });
                        page.Content().Column(column =>
                        {
                            column.Item().Image(programBytes).FitWidth();
                            column.Item().Image(genderBytes).FitWidth();
                            column.Item().Image(yearBytes).FitWidth();
                        });
                    });
                }).GeneratePdf(dialog.FileName);

                MessageBox.Show("PDF export completed.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
