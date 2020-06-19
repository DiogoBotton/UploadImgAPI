public class Conversor
{
    public static byte[] ImagemParaByte(Image imagem)
    {
        using (var stream = new MemoryStream())
        {
            imagem.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }
    }

    public static Image ByteParaImagem(byte[] bytes)
    {
        using (var stream = new MemoryStream(bytes))
        {
            return Image.FromStream(stream);
        }
    }
}

// Fonte: https://joaoretamero.com.br/salvando-imagens-csharp-entity/#:~:text=Preparando%20o%20modelo,usar%20um%20array%20de%20byte.&text=Neste%20caso%20o%20Entity%20j%C3%A1,a%20coluna%20na%20tabela%20corretamente.