using MySql.Data.MySqlClient;

namespace AppWebUriel.Configs
{
    public static class DAOHelper
    {
        // Lê uma string; se a coluna for NULL, devolve string vazia
        public static string GetString(MySqlDataReader reader, string column_name)
        {
            string text = string.Empty;
            if (!reader.IsDBNull(reader.GetOrdinal(column_name)))
                text = reader.GetString(column_name);
            return text;
        }

        // Lê um double; se a coluna for NULL, devolve 0.0
        public static double GetDouble(MySqlDataReader reader, string column_name)
        {
            double value = 0.0;
            if (!reader.IsDBNull(reader.GetOrdinal(column_name)))
                value = reader.GetDouble(column_name);
            return value;
        }

        // Lê uma data; se a coluna for NULL, devolve null
        public static DateTime? GetDateTime(MySqlDataReader reader, string column_name)
        {
            DateTime? value = null;
            if (!reader.IsDBNull(reader.GetOrdinal(column_name)))
                value = reader.GetDateTime(column_name);
            return value;
        }

        // Indica se uma coluna está NULL
        public static bool IsNull(MySqlDataReader reader, string column_name)
        {
            return reader.IsDBNull(reader.GetOrdinal(column_name));
        }

        public static DateOnly? GetDateOnly(MySqlDataReader reader, string column_name)
        {
            int ordinal = reader.GetOrdinal(column_name);

            if (reader.IsDBNull(ordinal))
                return null;

            var valor = reader.GetValue(ordinal);

            // Se o banco retornar DateTime, converte para DateOnly
            if (valor is DateTime dt)
                return DateOnly.FromDateTime(dt);

            // Se o driver já suportar DateOnly diretamente
            if (valor is DateOnly dOnly)
                return dOnly;

            // Caso venha como string ou outro formato conversível
            if (DateTime.TryParse(valor.ToString(), out var dtParsed))
                return DateOnly.FromDateTime(dtParsed);

            return null;
        }
    }

}
