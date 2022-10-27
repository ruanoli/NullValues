using Newtonsoft.Json;
using TiposEspeciais.Models;

bool? email = true;

//Se o valor for diferente denulo e for true.
//Sempre que trabalharmos com valores nulos
//antes de verificar se o valor é verdadeiro
//temos que verificar se o valor é nulo com .HasValue
//se não uma exceção será disparada.
//HasValue e =! null são a mesma coisa.
if(email.HasValue && email.Value)
{
    Console.WriteLine("Usuário optou por receber email.");
}
else
{
    Console.WriteLine("Usuário não respondeu a pesquisa ou optou por não receber email.");
}

//Tipos anônimos
var tipoAnonimo = new { Name = "Ruan", LastName = "Oliveira", Age = 27 };

//As propriedades serão somente para leitura, ou seja, get.
Console.WriteLine($"Nome: {tipoAnonimo.Name}");

//Tipos anônimos em coleções
//podemos armazenar somente algumas propriedades do nosso Json.
string file = File.ReadAllText("Files/sale.json");
List<Product> listSale = JsonConvert.DeserializeObject<List<Product>>(file);

//Selecionamos somente o elementos que queremos, e o retorno será uma lista anônima.
//A vantagem é que conseguimos limitar os elementos que queremos pegar do arquivo. 
var listAn = listSale.Select(x => new { x.Title, x.Price });

foreach(var item in listAn)
{
    Console.WriteLine($"Título: {item.Title} | Preço: {item.Price}");
}