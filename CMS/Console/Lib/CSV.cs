using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ConsoleCMS.Lib
{
    public class CSV<T> : FileResult
    {
         private readonly IList<T> _list;
        private readonly char _separator;

        public CSV(IList<T> list,
            string fileDownloadName,
            char separator = ',')
            : base("text/csv")
        {
            _list = list;
            FileDownloadName = fileDownloadName;
            _separator = separator;
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            var outputStream = response.OutputStream;
            using (var memoryStream = new MemoryStream())
            {
                WriteList(memoryStream);
                outputStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
        }

        private void WriteList(Stream stream)
        {
            var streamWriter = new StreamWriter(stream, Encoding.Default);

            WriteHeaderLine(streamWriter);
            streamWriter.WriteLine();
            WriteDataLines(streamWriter);

            streamWriter.Flush();
        }

        private void WriteHeaderLine(StreamWriter streamWriter)
        {
            foreach (MemberInfo member in typeof(T).GetProperties())
            {
                WriteValue(streamWriter, member.Name);
            }
        }

        private void WriteDataLines(StreamWriter streamWriter)
        {
            foreach (T line in _list)
            {
                foreach (MemberInfo member in typeof(T).GetProperties())
                {
                    WriteValue(streamWriter, GetPropertyValue(line, member.Name));
                }
                streamWriter.WriteLine();
            }
        }


        private void WriteValue(StreamWriter writer, String value)
        {
            writer.Write("\"");
            writer.Write(value.Replace("\"", "\"\""));
            writer.Write("\"" + _separator);
        }

        public static string GetPropertyValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null).ToString() ?? "";
        }
    }

    public class Participante
    {
        public string Tipo { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public int Ninos { get; set; }
        public int NumeroCentros { get; set; }
        public string FechaRegistro { get; set; }

        public static string JsonSerializer(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            return serializer.Serialize(obj);
        }

        public static dynamic DeserializarJSON(string json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = 500000000;
            return js.Deserialize<dynamic>(json);
        }
    }

    public class Grafica
    {
        public string Llave { get; set; }
        public string Valor { get; set; }


        public static string JsonSerializer(dynamic obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static dynamic DeserializarJSON(string json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Deserialize<dynamic>(json);
        }
    }

}