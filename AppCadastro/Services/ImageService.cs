using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastro.Services
{
    public static class ImageService
    {
        public static async Task<string> SelecionarImagem()
        {
            string diretorio = "";

            //Método para seleção da imagem
            var imagemSelecionada =
                await MediaPicker.PickPhotoAsync();
            if (imagemSelecionada != null)
                diretorio = imagemSelecionada.FullPath;

            return diretorio;
        }

        public static string CopiarImagemDirApp(string sDiretorioImagem)
        {
            string DiretorioDestino = "";

            if (!string.IsNullOrEmpty(sDiretorioImagem))
            {
                //Montar o diretorio junto do nome do noma da pasta
                //AppContext.BaseDirectory retorna o diretorio do aplicativo
                //OU seja se  dir for Ex: C:/APP
                //Irei combinar com o nome da pasta tendo o novo diretorio
                //novoDiretorio: C:/APP/Imagens
                var novoDiretorio =
                    Path.Combine(AppContext.BaseDirectory, "Imagens");

                //Verifico se o meu novoDiretorio existe
                //Se não existir crio a pasta
                if (!Directory.Exists(novoDiretorio))
                    Directory.CreateDirectory(novoDiretorio);

                //Monto o novo diretorio com o nome do arquivo
                //atual novoDiretorio: C:/APP/Imagens
                //Combinamos com o nome do arquivo
                //ficando DiretorioDestino: C:/APP/Imagens/Imagem.png
                DiretorioDestino =
                    Path.Combine(novoDiretorio,
                                Path.GetFileName(sDiretorioImagem));

                //Faço a copia da imagem para o DiretorioDestino
                //Ativo a opção de subistiuir a imagem caso ja exista
                File.Copy(sDiretorioImagem, 
                            DiretorioDestino, 
                            overwrite: true);
            }

            return DiretorioDestino;
        }
    }
}
