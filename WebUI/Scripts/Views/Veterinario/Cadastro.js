var Cadastro = {

    API_URL: "",
    UsuarioID: "",

    ViewModelCadastroVeterinario: new ViewModelCadastroVeterinario(),

    ListaPetTipos: [],

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;


        $("#veterinario_nome").focus();

        that.GetUsuario();
        that.GetPetTipos();
        that.GetFuncionarios();


        //OnClick botão "Salvar"
        $("#btn_veterinario_salvar").on("click", function () {
            that.SalvarVeterinario();
        });

        //OnClick botão "Cancelar"
        $("#btn_veterinario_cancelar").on("click", function () {
            location.reload();
        });

    },

    //Método para inicializar objeto ViewModelLogin
    InitializeFormData: function () {
        var that = this;

        var arr_vm_cadastro_veterinario_pet_tipo = [];

        $(".cbx-pet-tipo").each(function (element) {

            if ($(this).is(':checked')) {

                var pet_tipo_id = $(this).val();

                var vm_cadastro_veterinario_pet_tipo = new ViewModelCadastroVeterinarioPetTipo();
                vm_cadastro_veterinario_pet_tipo.cadastro_veterinario_pet_tipo_id_pet_tipo = pet_tipo_id;

                arr_vm_cadastro_veterinario_pet_tipo.push(vm_cadastro_veterinario_pet_tipo);

            }

        });


        that.ViewModelCadastroVeterinario.cadastro_veterinario_id = $("#veterinario_id").val();
        that.ViewModelCadastroVeterinario.cadastro_veterinario_nome = $("#veterinario_nome").val();
        that.ViewModelCadastroVeterinario.cadastro_veterinario_cpf = $("#veterinario_cpf").val();
        that.ViewModelCadastroVeterinario.cadastro_veterinario_identidade = $("#veterinario_identidade").val();
        that.ViewModelCadastroVeterinario.cadastro_veterinario_registro = $("#veterinario_registro").val();
        that.ViewModelCadastroVeterinario.cadastro_veterinario_id_funcionario = $("#veterinario_id_funcionario").val();
        that.ViewModelCadastroVeterinario.cadastro_veterinario_ultima_alteracao = $("#veterinario_ultima_alteracao").val();
        that.ViewModelCadastroVeterinario.cadastro_veterinario_responsavel = $("#veterinario_responsavel").val();

        that.ViewModelCadastroVeterinario.cadastro_veterinario_pet_tipo_list = arr_vm_cadastro_veterinario_pet_tipo;
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

                $("#veterinario_responsavel").val(usuario.nome);

            } else {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Buscar funcionarios
    GetFuncionarios: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Funcionario/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var lista_funcionarios = response_done;

            if (lista_funcionarios.length > 0) {

                for (var i = 0; i < lista_funcionarios.length; i++) {

                    var funcionario = lista_funcionarios[i];
                    $("#veterinario_id_funcionario").append("<option value='" + funcionario.id + "'>" + funcionario.nome + "</option>");

                }
                
            }

        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Buscar tipos de pets
    GetPetTipos: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/PetTipo/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var lista_pet_tipos = response_done;

            if (lista_pet_tipos.length > 0) {

                that.ListaPetTipos = lista_pet_tipos;
                that.CreateHTMLPetTipos();
            } 

        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para salvar veterinario
    SalvarVeterinario: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Veterinario/Cadastrar",
            data: that.ViewModelCadastroVeterinario,
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


    CreateHTMLPetTipos: function () {
        var that = this;

        if (that.ListaPetTipos.length > 0) {

            for (var i = 0; i < that.ListaPetTipos.length; i++) {

                var pet_tipo = that.ListaPetTipos[i];

                var element = "<label><input type='checkbox' class='cbx-pet-tipo' value='" + pet_tipo.id + "'>" + pet_tipo.descricao + "</label><br>";
                $("#veterinario_pet_tipo_content").append(element);

            }
        }
    }


}