﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBASE.DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class doggis_dbEntities : DbContext
    {
        public doggis_dbEntities()
            : base("name=doggis_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<agendamento> agendamento { get; set; }
        public virtual DbSet<atendente> atendente { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<cliente_pataz_entrada_produto> cliente_pataz_entrada_produto { get; set; }
        public virtual DbSet<cliente_pataz_entrada_servico> cliente_pataz_entrada_servico { get; set; }
        public virtual DbSet<cliente_pataz_saida_produto> cliente_pataz_saida_produto { get; set; }
        public virtual DbSet<cliente_pataz_saida_servico> cliente_pataz_saida_servico { get; set; }
        public virtual DbSet<estoque_entrada> estoque_entrada { get; set; }
        public virtual DbSet<estoque_saida> estoque_saida { get; set; }
        public virtual DbSet<funcionario> funcionario { get; set; }
        public virtual DbSet<pet> pet { get; set; }
        public virtual DbSet<pet_tipo> pet_tipo { get; set; }
        public virtual DbSet<produto> produto { get; set; }
        public virtual DbSet<promocao> promocao { get; set; }
        public virtual DbSet<promocao_produto> promocao_produto { get; set; }
        public virtual DbSet<promocao_servico> promocao_servico { get; set; }
        public virtual DbSet<servico> servico { get; set; }
        public virtual DbSet<servico_produto> servico_produto { get; set; }
        public virtual DbSet<servico_valor> servico_valor { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<usuario_tipo> usuario_tipo { get; set; }
        public virtual DbSet<venda> venda { get; set; }
        public virtual DbSet<venda_produto> venda_produto { get; set; }
        public virtual DbSet<venda_produto_pagamento> venda_produto_pagamento { get; set; }
        public virtual DbSet<venda_servico> venda_servico { get; set; }
        public virtual DbSet<venda_servico_pagamento> venda_servico_pagamento { get; set; }
        public virtual DbSet<veterinario> veterinario { get; set; }
        public virtual DbSet<veterinario_pet_tipo> veterinario_pet_tipo { get; set; }
    }
}
