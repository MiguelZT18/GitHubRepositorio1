using System.Collections;

//definicion e inicialización de los arreglos en paralelo y el diccionario
String[] Departamento = { "Boaco", "Carazo", "Chinandega", "Chontales", "Costa Caribe Norte", "Costa Caribe Sur",
    "Estelí", "Granada", "Jinotega", "León", "Madriz", "Managua", "Masaya", "Matagalpa", "Nueva Segovia", "Río San Juan", "Rivas" };

int[] Poblacion = { 180501, 193719, 439996, 198083, 530868, 414543, 229866, 214377, 456930, 421050, 174744, 1549649, 391903, 593503, 271581, 135446, 182645 };

Dictionary<string, int> diccionario = Departamento
    .Zip(Poblacion, (k, v) => new { Clave = k, Valor = v })
    .ToDictionary(x => x.Clave, x => x.Valor);

//Ordenando el diccionario de menor a mayor
var ordenado = diccionario.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

//hallando los nombres de los departamentos con menor y mayor poblacion
string minDepKey = ordenado.First().Key;
string maxDepKey = ordenado.Last().Key;

//desagregación de los arreglos en paralelo
Departamento = ordenado.Keys.ToArray();
Poblacion = ordenado.Values.ToArray();

//Mostrar los arreglos ordenados de menor a mayor.
for (int i = 0; i < Poblacion.Length; i++)
{
    Console.WriteLine($"{Departamento[i],20} => {Poblacion[i],10:N0}");
}

//Suma de toda la población y nombre mayor y menor
Console.WriteLine($"Población General:{Poblacion.Sum():N0}");
Console.WriteLine($"mayor Población:{maxDepKey}");
Console.WriteLine($"menor Población:{minDepKey}");
