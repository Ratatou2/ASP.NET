using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Playground.Models
{
    public class Test
    {
        [MinLength(3, ErrorMessage = "ID의 최소 길이는 3자리 이상이어야 합니다")]
        public string _Id { get; set; }
        [MinLength(5, ErrorMessage = "PW의 최소 길이는 5자리 이상이어야 합니다")]
        public string _password { get; set; }
        public string _name { get; set; }

        public byte _age { get; set; }
        [Required(ErrorMessage = "회원가입 동의는 반드시 체크되어야 합니다")]
        public bool _checkJoin { get; set; }

    }
}
