using ConsoleApp1;
using ConsoleApp1.clase8;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {

        var listaUsuarios = new List<Usuario>();
        var listaProductos = new List<Producto>();


        SqlConnectionStringBuilder conecctionbuilder = new();
        conecctionbuilder.DataSource = "DAVID-LAPTOP";
        conecctionbuilder.InitialCatalog = "SistemaGestion";
        conecctionbuilder.IntegratedSecurity = true;
        var cs = conecctionbuilder.ConnectionString;

        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM producto";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var produc = new Producto();

                produc.Id = Convert.ToInt32(reader.GetValue(0));
                produc.Descripciones = reader.GetValue(1).ToString();
                produc.Costo = Convert.ToDouble(reader.GetValue(2));
                produc.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                produc.Stock = Convert.ToInt32(reader.GetValue(4));
                produc.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                listaProductos.Add(produc);

            }

            Console.WriteLine("---- PRODUCTOS ----- ");
            foreach (var produc in listaProductos)
            {
                Console.WriteLine("id = " + produc.Id);
                Console.WriteLine("Descripciones = " + produc.Descripciones);
                Console.WriteLine("Costo = " + produc.Costo);
                Console.WriteLine("PrecioVenta = " + produc.PrecioVenta);
                Console.WriteLine("Stock = " + produc.Stock);
                Console.WriteLine("IdUsuario = " + produc.IdUsuario);

                Console.WriteLine("--------------");

            }
            reader.Close();

            SqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "SELECT * FROM usuario";
            var reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {
                var usuario = new Usuario();

                usuario.Id = Convert.ToInt32(reader2.GetValue(0));
                usuario.Nombre = reader2.GetValue(1).ToString();
                usuario.Apellido = reader2.GetValue(2).ToString();
                usuario.NombreUsuario = reader2.GetValue(3).ToString();
                usuario.Contraseña = reader2.GetValue(4).ToString();
                usuario.Mail = reader2.GetValue(5).ToString();

                listaUsuarios.Add(usuario);

            }

            Console.WriteLine("---- USUARIOS ----- ");
            foreach (var usuario in listaUsuarios)
            {
                Console.WriteLine("id = " + usuario.Id);
                Console.WriteLine("Nombre = " + usuario.Nombre);
                Console.WriteLine("Costo = " + usuario.Apellido);
                Console.WriteLine("PrecioVenta = " + usuario.NombreUsuario);
                Console.WriteLine("Stock = " + usuario.Contraseña);
                Console.WriteLine("IdUsuario = " + usuario.Mail);
                Console.WriteLine("--------------");

            }
            reader2.Close();

        }
    }
}