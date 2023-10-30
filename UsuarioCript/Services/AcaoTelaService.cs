namespace UsuarioCript.Services
{
    //O tipo "enum" representa um enumerador, ou seja,
    //ele possui uma lista de valores e cada item da lista
    //tem um valor sequencial.
    //Da forma que está sendo utilizado abaixo, o item
    //"Inserir" vale 0 (zero) e o "Alterar" vale 1 (um).
    //Se outro item for inserido após o "Alterar" ele
    //valerá 2 (dois).
    public enum AcaoTelaService
    {
        Inserir,
        Alterar,
        Visualizar
    }
}
