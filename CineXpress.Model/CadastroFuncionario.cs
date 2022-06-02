﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CineXpress.Model
{
    public partial class CadastroFuncionario
    {
        public CadastroFuncionario()
        {
            Relacional = new HashSet<Relacional>();
        }

        [Key]
        [Column("idF")]
        public int IdF { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string NomeFuncionario { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Email { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Senha { get; set; }
        [Column("CPF")]
        [StringLength(15)]
        [Unicode(false)]
        public string Cpf { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string Celular { get; set; }

        [InverseProperty("IdFuncionarioNavigation")]
        public virtual ICollection<Relacional> Relacional { get; set; }
    }
}