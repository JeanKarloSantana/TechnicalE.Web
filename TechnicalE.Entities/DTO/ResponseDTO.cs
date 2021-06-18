using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalE.Entities.DTO
{
    public class ResponseDTO<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
        public ushort StatusCode { get; set; }        

        public ResponseDTO()
        {
            Errors = new List<string>();
            Succeeded = true;
        }
    }
}
