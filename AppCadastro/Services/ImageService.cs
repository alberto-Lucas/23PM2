namespace AppCadastro.Services
{
    public static class ImageService
    {
        public static async Task<string> SelecionarImagem()
        {
            string diretorio = "";

            var imagemSelecionada = await MediaPicker.PickPhotoAsync();
            if (imagemSelecionada != null)
            {
                diretorio = imagemSelecionada.FullPath;
            }

            return diretorio;
        }

        public static string CopiarImagemDirApp(string sDiretorioImagem)
        {
            string sDiretorioDestino = "";

            if (!string.IsNullOrEmpty(sDiretorioImagem))
            {
                var novoDirectorio = Path.Combine(AppContext.BaseDirectory, "SavedImages");

                if (!Directory.Exists(novoDirectorio))
                    Directory.CreateDirectory(novoDirectorio);

                sDiretorioDestino = Path.Combine(novoDirectorio, Path.GetFileName(sDiretorioImagem));

                File.Copy(sDiretorioImagem, sDiretorioDestino, overwrite: true);
            }

            return sDiretorioDestino;
        }
    }
}
