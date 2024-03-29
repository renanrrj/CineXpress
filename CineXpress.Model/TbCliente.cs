﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CineXpress.Model
{
    [Table("tb_Cliente")]
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbRelacional = new HashSet<TbRelacional>();
        }

        [Key]
        [Column("cli_Id")]
        public int CliId { get; set; }
        [Column("cli_Nome")]
        [StringLength(50)]
        [Unicode(false)]
        public string CliNome { get; set; }
        [Column("cli_Email")]
        [StringLength(50)]
        [Unicode(false)]
        public string CliEmail { get; set; }
        [Column("cli_Senha")]
        [StringLength(50)]
        [Unicode(false)]
        public string CliSenha { get; set; }
        [Column("cli_CPF")]
        [StringLength(15)]
        [Unicode(false)]
        public string CliCpf { get; set; }
        [Column("cli_DataNascimento", TypeName = "date")]
        public DateTime? CliDataNascimento { get; set; }
        [Column("cli_Celular")]
        [StringLength(12)]
        [Unicode(false)]
        public string CliCelular { get; set; }

        [InverseProperty("RelIdClienteNavigation")]
        public virtual ICollection<TbRelacional> TbRelacional { get; set; }
    }
}