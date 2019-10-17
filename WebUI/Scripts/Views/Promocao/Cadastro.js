var Cadastro = {

    API_URL: "",
    UsuarioID: "",

    ViewModelCadastroPromocao: new ViewModelCadastroPromocao(),

    ListaProdutos: [],
    ListaServicos: [],

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;


        $("#promocao_descricao").focus();

        that.GetUsuario();
        that.GetProdutos();
        that.GetServicos();


        //OnClick botão "Salvar"
        $("#btn_promocao_salvar").on("click", function () {
            that.SalvarPromocao();
        });

        //OnClick botão "Cancelar"
        $("#btn_promocao_cancelar").on("click", function () {
            location.reload();
        });

    },

    //Método para inicializar objeto ViewModelLogin
    InitializeFormData: function () {
        var that = this;

        var arr_vm_cadastro_promocao_produto = [];

        $(".cbx-produto").each(function (element) {

            if ($(this).is(':checked')) {

                var produto_id = $(this).val();

                var vm_cadastro_promocao_produto = new ViewModelCadastroPromocaoProduto();
                vm_cadastro_promocao_produto.cadastro_promocao_produto_id_produto = produto_id;

                arr_vm_cadastro_promocao_produto.push(vm_cadastro_promocao_produto);

            }

        });

        var arr_vm_cadastro_promocao_servico = [];

        $(".cbx-servico").each(function (element) {

            if ($(this).is(':checked')) {

                var servico_id = $(this).val();

                var vm_cadastro_promocao_servico = new ViewModelCadastroPromocaoServico();
                vm_cadastro_promocao_servico.cadastro_promocao_servico_id_servico = servico_id;

                arr_vm_cadastro_promocao_servico.push(vm_cadastro_promocao_servico);

            }

        });


        that.ViewModelCadastroPromocao.cadastro_promocao_id = $("#promocao_id").val();
        that.ViewModelCadastroPromocao.cadastro_promocao_descricao = $("#promocao_descricao").val();
        that.ViewModelCadastroPromocao.cadastro_promocao_porcentagem = $("#promocao_porcentagem").val();
        that.ViewModelCadastroPromocao.cadastro_promocao_data_inicio = $("#promocao_data_inicio").val();
        that.ViewModelCadastroPromocao.cadastro_promocao_data_termino = $("#promocao_data_termino").val();
        that.ViewModelCadastroPromocao.cadastro_promocao_ultima_alteracao = $("#promocao_ultima_alteracao").val();
        that.ViewModelCadastroPromocao.cadastro_promocao_responsavel = $("#promocao_responsavel").val();

        that.ViewModelCadastroPromocao.cadastro_promocao_promocao_produto_list = arr_vm_cadastro_promocao_produto;
        that.ViewModelCadastroPromocao.cadastro_promocao_promocao_servico_list = arr_vm_cadastro_promocao_servico;
    },

    //Método para buscar usuario logado
    GetUsuario: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Usuario/GetUsuario?usuario_id=" + that.UsuarioID,
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var usuario = response_done;

            if (usuario.id != "" && usuario.id != "undefined") {

                $("#promocao_responsavel").val(usuario.nome);

            } else {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Buscar produtos
    GetProdutos: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Produto/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var lista_produtos = response_done;

            if (lista_produtos.length > 0) {

                that.ListaProdutos = lista_produtos;
                that.CreateHTMLProdutos();
            }

        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Buscar servicos
    GetServicos: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Servico/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var lista_servicos = response_done;

            if (lista_servicos.length > 0) {

                that.ListaServicos = lista_servicos;
                that.CreateHTMLServicos();
            }

        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para salvar veterinario
    SalvarPromocao: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Promocao/Cadastrar",
            data: that.ViewModelCadastroPromocao,
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            if (response_done == true) {
                that.PosProcessSuccess();
            } else {
                that.PosProcessFail();
            }

        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            that.PosProcessFail();

        });

    },

    PreProcees: function () {
        $("#content_form_button").addClass("d-none");
        $("#content_form_message").addClass("d-none");
        $("#content_form_loader").removeClass("d-none");
        $("#message_success").addClass("d-none");
        $("#message_fail").addClass("d-none");
    },

    PosProcessSuccess: function () {
        $("#content_form_button").addClass("d-none");
        $("#content_form_message").removeClass("d-none");
        $("#content_form_loader").addClass("d-none");

        $("#message_success").removeClass("d-none");
        $("#message_fail").addClass("d-none");
    },

    PosProcessFail: function () {
        $("#content_form_button").removeClass("d-none");
        $("#content_form_message").removeClass("d-none");
        $("#content_form_loader").addClass("d-none");

        $("#message_success").addClass("d-none");
        $("#message_fail").removeClass("d-none");
    },


    CreateHTMLProdutos: function () {
        var that = this;

        if (that.ListaProdutos.length > 0) {

            for (var i = 0; i < that.ListaProdutos.length; i++) {

                var produto = that.ListaProdutos[i];

                var element = "<label><input type='checkbox' class='cbx-produto' value='" + produto.id + "'>" + produto.nome + "</label><br>";
                $("#promocao_produtos_content").append(element);

            }
        }
    },

    CreateHTMLServicos: function () {
        var that = this;

        if (that.ListaServicos.length > 0) {

            for (var i = 0; i < that.ListaServicos.length; i++) {

                var servico = that.ListaServicos[i];

                var element = "<label><input type='checkbox' class='cbx-servico' value='" + servico.id + "'>" + servico.nome + "</label><br>";
                $("#promocao_servicos_content").append(element);

            }
        }
    }


}