var Cadastro = {

    API_URL: "",
    UsuarioID: "",

    ViewModelCadastroServico: new ViewModelCadastroServico(),

    ListaProdutos: [],

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;


        $("#servico_nome").focus();

        that.GetUsuario();
        that.GetProdutos();


        //OnClick botão "Salvar"
        $("#btn_servico_salvar").on("click", function () {
            that.SalvarServico();
        });

        //OnClick botão "Cancelar"
        $("#btn_servico_cancelar").on("click", function () {
            location.reload();
        });

    },

    //Método para inicializar objeto ViewModelLogin
    InitializeFormData: function () {
        var that = this;

        var arr_vm_cadastro_servico_produto = [];

        $(".cbx-servico-produto").each(function (element) {

            if ($(this).is(':checked')) {

                var produto_id = $(this).val();
                var produto_quantidade = $("#servico_produto_quantidade_" + produto_id).val();

                var vm_cadastro_servico_produto = new ViewModelCadastroServicoProduto();
                vm_cadastro_servico_produto.cadastro_servico_produto_id_produto = produto_id;
                vm_cadastro_servico_produto.cadastro_servico_produto_quantidade = produto_quantidade;

                arr_vm_cadastro_servico_produto.push(vm_cadastro_servico_produto);

            }

        });


        that.ViewModelCadastroServico.cadastro_servico_id = $("#servico_id").val();
        that.ViewModelCadastroServico.cadastro_servico_nome = $("#servico_nome").val();
        that.ViewModelCadastroServico.cadastro_servico_descricao = $("#servico_descricao").val();
        that.ViewModelCadastroServico.cadastro_servico_valor_atual = $("#servico_valor_atual").val();
        that.ViewModelCadastroServico.cadastro_servico_tempo = $("#servico_tempo").val();
        that.ViewModelCadastroServico.cadastro_servico_pataz_bonus = $("#servico_pataz_bonus").val();
        that.ViewModelCadastroServico.cadastro_servico_pataz_custo = $("#servico_pataz_custo").val();
        that.ViewModelCadastroServico.cadastro_servico_tipo_executante = $("#servico_tipo_executante").val();
        that.ViewModelCadastroServico.cadastro_servico_ultima_alteracao = $("#servico_ultima_alteracao").val();
        that.ViewModelCadastroServico.cadastro_servico_responsavel = $("#servico_responsavel").val();

        that.ViewModelCadastroServico.cadastro_servico_produto_list = arr_vm_cadastro_servico_produto;
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

                $("#servico_responsavel").val(usuario.nome);

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

    //Método para salvar veterinario
    SalvarServico: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Servico/Cadastrar",
            data: that.ViewModelCadastroServico,
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

                var element = "<div class='form-group row'>";
                element += "        <label class='col-sm-2 col-form-label'><input type='checkbox' class='cbx-servico-produto' value='" + produto.id + "'>" + produto.nome + "</label>";
                element += "        <div class='col-sm-10'>";
                element += "            <input type='number' id='servico_produto_quantidade_" + produto.id + "' placeholder='Informe a quantidade de produto'>";
                element += "        </div>";
                element += "   </div>";

                $("#servico_produtos_content").append(element);

            }
        }
    }


}