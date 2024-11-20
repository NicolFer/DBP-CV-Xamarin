using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Reflection;

namespace CV1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GenerateStaticPdf(); // Llama la función al cargar la página
        }

        private async void GenerateStaticPdf()
        {
            // Crear PDF
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            // Estilo de texto
            PdfFont titleFont = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);
            PdfFont boldFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
            PdfFont regularFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            PdfFont smallFont = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
            PdfFont jobTitleFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);

            // Color 
            Syncfusion.Drawing.Color paleLilac = Syncfusion.Drawing.Color.FromArgb(216, 191, 216);

            // Tamaño página
            float pageWidth = page.GetClientSize().Width;
            float pageHeight = page.GetClientSize().Height;

            Syncfusion.Drawing.Color darkPurple = Syncfusion.Drawing.Color.FromArgb(102, 51, 153); // Lila oscuro
            graphics.DrawRectangle(new PdfSolidBrush(darkPurple), new Syncfusion.Drawing.RectangleF(0, 0, pageWidth, 110));

            // Dibuja fondo columna izquierda 
            Syncfusion.Drawing.Color lightLilacGray = Syncfusion.Drawing.Color.FromArgb(220, 200, 230); // Gris lila claro
            graphics.DrawRectangle(new PdfSolidBrush(lightLilacGray), new Syncfusion.Drawing.RectangleF(0, 110, 150, pageHeight - 110));

            // Cargar imagen 
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream imageStream = assembly.GetManifestResourceStream("CV1.Resources.Images.mi_imagen.jpg"); // Ajusta la ruta
            PdfImage image = null;
            if (imageStream != null)
            {
                image = PdfImage.FromStream(imageStream);
                graphics.DrawImage(image, new Syncfusion.Drawing.RectangleF(10, 10, 90, 90)); // Imagen en el encabezado
            }

            // Alineación texto
            float headerTextStartX = 160; // Posición después de la columna izquierda

            // Título en blanco
            graphics.DrawString("Curriculum Vitae", titleFont, PdfBrushes.White, new Syncfusion.Drawing.PointF(headerTextStartX, 20));

            // alineados a la columna derecha
            graphics.DrawString("Nombre: Juan Muños Díaz", regularFont, PdfBrushes.White, new Syncfusion.Drawing.PointF(headerTextStartX, 60));
            graphics.DrawString("Trabajo esperado: Desarrollador de Software", regularFont, PdfBrushes.White, new Syncfusion.Drawing.PointF(headerTextStartX, 80));

            // Columna izquierda
            float leftMargin = 10;
            float currentY = 120;
            float lineSpacing = 5; // Espaciado entre título y línea

            // contacto
            graphics.DrawString("Contacto:", boldFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 15;
            graphics.DrawLine(PdfPens.Black, leftMargin, currentY, 140, currentY);
            currentY += lineSpacing;
            graphics.DrawString("- Teléfono: 123-456-7890", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Email: seb.md.t@email.com", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));

            // Habilidades
            currentY += 30;
            graphics.DrawString("Habilidades:", boldFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 15;
            graphics.DrawLine(PdfPens.Black, leftMargin, currentY, 140, currentY);
            currentY += lineSpacing;
            graphics.DrawString("- Gran capacidad analítica", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Captura de registros", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Interpretación de los datos", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Orientación a objetivos", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Trabajo con Big Data", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Modelos matemáticos", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));

            // Idiomas
            currentY += 30;
            graphics.DrawString("Idiomas:", boldFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 15;
            graphics.DrawLine(PdfPens.Black, leftMargin, currentY, 140, currentY);
            currentY += lineSpacing;
            graphics.DrawString("- Español", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Inglés", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Alemán", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Francés", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));

            // Otros
            currentY += 30;
            graphics.DrawString("Otros:", boldFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 15;
            graphics.DrawLine(PdfPens.Black, leftMargin, currentY, 140, currentY);
            currentY += lineSpacing;
            graphics.DrawString("- Creatividad", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Trabajo en equipo", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Resolución de problemas", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Diseño de id corporativa", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));
            currentY += 20;
            graphics.DrawString("- Planeación de redes sociales", smallFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(leftMargin, currentY));

            // Columna derecha 
            float rightMargin = 160;
            currentY = 120;

            // Sobre mí
            graphics.DrawString("Sobre mí:", boldFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(rightMargin, currentY));
            currentY += 15;
            graphics.DrawLine(PdfPens.Black, rightMargin, currentY, pageWidth - 10, currentY);
            currentY += lineSpacing;
            DrawTextWithWrapping(graphics, "Científico de datos con una larga trayectoria en el sector tras 13 años de experiencia. Capaz de generar modelos predictivos e interpretar estadísticas para ofrecer recomendaciones útiles para el negocio. En busca de empleo en un entorno dinámico donde poner en práctica mis habilidades.", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);

            // Experiencia laboral
            currentY += 45;
            graphics.DrawString("Experiencia laboral:", boldFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(rightMargin, currentY));
            currentY += 15;
            graphics.DrawLine(PdfPens.Black, rightMargin, currentY, pageWidth - 10, currentY);
            currentY += lineSpacing;
            DrawTextWithWrapping(graphics, "Científico de datos (2018-2021)", jobTitleFont, paleLilac, rightMargin, currentY, pageWidth - rightMargin - 10); // Año en lila pálido
            currentY += 20;
            DrawTextWithWrapping(graphics, "• Extracción de datos, procesamiento, registro y análisis de estos y posterior reporting.", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);
            currentY += 25;
            DrawTextWithWrapping(graphics, "• Desarrollo de reportes mediante hojas de cálculo y funciones automáticas.", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);
            currentY += 15;
            DrawTextWithWrapping(graphics, "• Generación de análisis de datos y planteo de estrategias para sustentar la toma de decisiones.", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);
            currentY += 30;
            DrawTextWithWrapping(graphics, "Analista de datos (2021-2023)", jobTitleFont, paleLilac, rightMargin, currentY, pageWidth - rightMargin - 10); // Año en lila pálido
            currentY += 20;
            DrawTextWithWrapping(graphics, "• Integración de datos de múltiples fuentes y plataformas para análisis unificado.", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);
            currentY += 25;
            DrawTextWithWrapping(graphics, "• Colaboración con equipos multidisciplinarios para definir objetivos y métricas.", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);
            currentY += 22;
            DrawTextWithWrapping(graphics, "• Creación de modelos predictivos y algoritmos de aprendizaje automático.", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);
            currentY += 25;
            DrawTextWithWrapping(graphics, "Científico de datos (2023-actual)", jobTitleFont, paleLilac, rightMargin, currentY, pageWidth - rightMargin - 10); // Año en lila pálido
            currentY += 20;
            DrawTextWithWrapping(graphics, "• Detección y propuesta de oportunidades de mejora según la información analizada.", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);
            currentY += 25;
            DrawTextWithWrapping(graphics, "• Aplicación de paquetes estadísticos para el análisis de conjuntos de datos.", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);
            currentY += 15;
            DrawTextWithWrapping(graphics, "• Identificación de patrones, vínculos y tendencias de comportamiento de datos a gran escala.", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);

            // Formación académica
            currentY += 40;
            graphics.DrawString("Formación académica:", boldFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(rightMargin, currentY));
            currentY += 15;
            graphics.DrawLine(PdfPens.Black, rightMargin, currentY, pageWidth - 10, currentY);
            currentY += lineSpacing;

            // formación académica
            DrawTextWithWrapping(graphics, "Maestría en Inteligencia de Negocios y Big Data (07/2011)", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);
            currentY += 17;
            DrawTextWithWrapping(graphics, "Global Open University - Online ", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);
            currentY += 20;
            DrawTextWithWrapping(graphics, "Licenciatura en Matemáticas (07/2010)", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);
            currentY += 17;
            DrawTextWithWrapping(graphics, "Universidad Católica San Pablo - Perú ", smallFont, Syncfusion.Drawing.Color.Black, rightMargin, currentY, pageWidth - rightMargin - 10);

            // Guardar el PDF como archivo
            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream);
                document.Close(true);

                // Guardar en el dispositivo
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CV_Estilo.pdf");
                File.WriteAllBytes(filePath, stream.ToArray());

                if (File.Exists(filePath))
                {
                    await Launcher.OpenAsync(new OpenFileRequest
                    {
                        File = new ReadOnlyFile(filePath)
                    });
                }
                else
                {
                    await DisplayAlert("Error", "El archivo PDF no se generó correctamente o no se encontró.", "OK");
                }

                // Mostrar un mensaje al usuario en la app cv
                await DisplayAlert("PDF Generado", $"El CV ha sido guardado en:\n{filePath}", "OK");
            }
        }

        // Método para dibujar texto con ajuste de línea
        private void DrawTextWithWrapping(PdfGraphics graphics, string text, PdfFont font, Syncfusion.Drawing.Color color, float x, float y, float width)
        {
            PdfStringFormat format = new PdfStringFormat();
            format.WordWrap = PdfWordWrapType.Word;
            graphics.DrawString(text, font, new PdfSolidBrush(color), new Syncfusion.Drawing.RectangleF(x, y, width, 0), format);
        }
    }
}
