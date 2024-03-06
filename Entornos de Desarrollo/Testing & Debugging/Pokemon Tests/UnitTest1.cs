namespace Pokemon_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Ok1()
        {
            string result = Program.StrongestPokemon("pokemon.csv", 1); // OK, Valor Esperado.
            Assert.AreEqual("GyaradosMega Gyarados", result);
        }

        [TestMethod]
        public void Ok2()
        {
            string result = Program.StrongestPokemon("pokemon.csv", 2); // OK, Valor Esperado.
            Assert.AreEqual("HeracrossMega Heracross", result);
        }

        [TestMethod]
        public void Ok3()
        {
            string result = Program.StrongestPokemon("pokemon.csv", 3); // OK, Valor Esperado.
            Assert.AreEqual("BanetteMega Banette", result);
        }

        [TestMethod]
        public void Ok4()
        {
            string result = Program.StrongestPokemon("pokemon.csv", 4); // OK, Valor Esperado.
            Assert.AreEqual("GarchompMega Garchomp", result);
        }

        [TestMethod]
        public void Ok5()
        {
            string result = Program.StrongestPokemon("pokemon.csv", 5); // OK, Valor Esperado.
            Assert.AreEqual("Haxorus", result);
        }

        [TestMethod]
        public void Ok6()
        {
            string result = Program.StrongestPokemon("pokemon.csv", 6); // OK, Valor Esperado.
            Assert.AreEqual("AegislashBlade Forme", result);
        }

        [TestMethod]
        public void ErrorLimite1()
        {
            string result = Program.StrongestPokemon("pokemon.csv", 0); // Da Error Está Fuera de los Límites de los Valores Aceptados.
            Assert.AreEqual("Error", result);
        }

        [TestMethod]
        public void ErrorLimite2()
        {
            string result = Program.StrongestPokemon("pokemon.csv", 7); // Da Error Está Fuera de los Límites de los Valores Aceptados.
            Assert.AreEqual("Error", result);
        }

        [TestMethod]
        public void ErrorTipo1()
        {
            string result = Program.StrongestPokemon("pokemon.csv", 'a'); // Da Error el Segundo Parámetro no Acepta Caracteres.
            Assert.AreEqual("Error", result);
        }

        [TestMethod]
        public void ErrorEmpty1() // Da el Mismo Error que Pasándole NULL, ErrorNULL1().
        {
            string result = Program.StrongestPokemon("", 3);
            Assert.AreEqual("Error", result);
        }

        [TestMethod]
        public void ErrorNULL1() // Da el Mismo Error que Pasándole "" (String Vacia), ErrorEmpty1().
        {
            string result = Program.StrongestPokemon(null, 3);
            Assert.AreEqual("Error", result);
        }

        [TestMethod]
        public void ErrorPath1() // Llama al Método Pasándole NULL, da Error ya que no Acepta Valores NULL.
        {
            Program.FilterPokemon(null);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ErrorPath2() // Llama al Método Pasándole Una Ruta Relativa, Como la Carpeta No Existe da Error.
        {
            FilterPokemon("Documents");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void OkPath1() // Llama al Método Pasándole una Ruta en este Caso en la Misma Carpeta Donde Está el Ejecutable del Proyecto(String Vacia).
        {
            FilterPokemon("");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void OkPath2() // Llama al Método Pasándole la Ruta Absoluta a Documentos del Usuario del Equipo.
        {
            FilterPokemon($"C:\\Users\\{Environment.UserName}\\Documents");
            Assert.IsTrue(true);
        }

        public static void FilterPokemon(string rutaFichero) // Método para Guardar los Pokemon de 2 Tipos en un Fichero.
        {
            List<string>? listLines = ["Uno,Dos,Tres,Cuatro", "Cuatro,Cinco,Seis,Siete", "Siete,Ocho,Nueve,Diez"];
            string filename = "pokemonDosTiposTest.csv"; // Nombre del Fichero.

            using StreamWriter outputFile = new(Path.Combine(rutaFichero, filename)); // Crea un StreamWriter, para Almacenar en un Fichero.
            foreach (string line in listLines) // Para Cada Línea de listLines (Lista en la que Están las Líneas Separadas por , de los Pokemon).
            {
                string[] aux = line.Split(','); // Hago un split por la , en el Array de Strings aux.
                if (aux[2] != "" && aux[3] != "") // Compruebo si los Índices 2 y 3 en el Array aux no están Vacios.
                {
                    outputFile.WriteLine(line); // Escribe en el Fichero la Linea Completa.
                }
            }
        }
    }
}