using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace AdicionarTextoNaImagem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lê a imagem original
            Image imagemOriginal = Image.FromFile(@"C:\Users\lgfreitas\Downloads\0333d306-b71a51766a55a46e7f16464088400026-1024-1024.jpg");

            // Cria uma nova imagem com o mesmo tamanho da original
            var imagemModificada = new Bitmap(imagemOriginal.Width, imagemOriginal.Height);

            // Desenha a imagem original na nova imagem
            using (Graphics g = Graphics.FromImage(imagemModificada))
            {
                g.DrawImage(imagemOriginal, new Point(0, 0));

                // Adiciona a string no meio da imagem
                string texto = "Teste!!!!!";
                Font fonte = new Font("Arial", 12, FontStyle.Bold);
                SizeF tamanhoDoTexto = g.MeasureString(texto, fonte);

                Point posicao = new Point(
                    (int)(imagemOriginal.Width / 2 - tamanhoDoTexto.Width / 2),
                    (int)(imagemOriginal.Height / 2 - tamanhoDoTexto.Height / 2)
                );

                g.DrawString(texto, fonte, Brushes.Red, posicao);
            }

            // Salva a imagem modificada
            imagemModificada.Save(@"C:\Users\lgfreitas\Downloads\0333d306-b71a51766a55a46e7f16464088400026-1024-1024_Mod.jpg", ImageFormat.Jpeg);

            // Limpa as imagens
            imagemOriginal.Dispose();
            imagemModificada.Dispose();
        }
    }
}
