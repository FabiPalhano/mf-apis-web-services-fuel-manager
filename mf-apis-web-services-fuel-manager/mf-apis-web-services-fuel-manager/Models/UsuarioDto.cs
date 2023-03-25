﻿using System.ComponentModel.DataAnnotations;

namespace mf_apis_web_services_fuel_manager.Models
{
    public class UsuarioDto
    {
        public int? Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]        
        public string Password { get; set; }

        [Required]
        public Perfil Perfil { get; set; }
    }
}

//usuario usado como interface para as requisições, porque não irá retornar o password que vem do banco de dados