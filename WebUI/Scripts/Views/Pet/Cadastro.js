var Cadastro = {

    API_URL: "",
    UsuarioID: "",

    ViewModelCadastroPet: new ViewModelCadastroPet(),

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;


        $("#pet_id_pet_tipo").focus();

        that.GetUsuario();
        that.GetPetTipos();
        that.GetClientes();

        //OnClick botão "Salvar"
        $("#btn_pet_salvar").on("click", function () {
            that.SalvarPet();
        });

        //OnClick botão "Cancelar"
        $("#btn_pet_cancelar").on("click", function () {
            location.reload();
        });

    },

    //Método para inicializar objeto ViewModelCadastroPet
    InitializeFormData: function () {
        var that = this;

        that.ViewModelCadastroPet.cadastro_pet_id = $("#pet_id").val();
        that.ViewModelCadastroPet.cadastro_pet_id_pet_tipo = $("#pet_id_pet_tipo").val();
        that.ViewModelCadastroPet.cadastro_pet_id_cliente = $("#pet_id_cliente").val();
        that.ViewModelCadastroPet.cadastro_pet_nome = $("#pet_nome").val();
        that.ViewModelCadastroPet.cadastro_pet_raca = $("#pet_raca").val();
        that.ViewModelCadastroPet.cadastro_pet_porte = $("#pet_porte").val();
        that.ViewModelCadastroPet.cadastro_pet_alergias = $("#pet_alergias").val();
        that.ViewModelCadastroPet.cadastro_pet_observacao = $("#pet_observacao").val();

        if ($("#pet_autorizacao").checked) {
            that.ViewModelCadastroPet.cadastro_pet_autorizacao = "S";
        } else {
            that.ViewModelCadastroPet.cadastro_pet_autorizacao = "N";
        }

        that.ViewModelCadastroPet.cadastro_pet_ultima_alteracao = $("#pet_ultima_alteracao").val();
        that.ViewModelCadastroPet.cadastro_pet_responsavel = $("#pet_responsavel").val();
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

                $("#pet_responsavel").val(usuario.nome);

            } else {
                //window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            //window.location = "Error";

        });
    },

    //Método para buscar tipos de pets
    GetPetTipos: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/PetTipo/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var pet_tipos = response_done;

            if (pet_tipos != "" && pet_tipos != "undefined" && pet_tipos.length > 0) {

                for (var i = 0; i < pet_tipos.length; i++) {

                    var pet_tipo = pet_tipos[i];

                    $("#pet_id_pet_tipo").append("<option value='" + pet_tipo.id + "'>" + pet_tipo.descricao + "</option>");

                }

            } else {
                //window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            //window.location = "Error";

        });
    },

    //Método para buscar clientes
    GetClientes: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Cliente/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var clientes = response_done;

            if (clientes != "" && clientes != "undefined" && clientes.length > 0) {

                for (var i = 0; i < clientes.length; i++) {

                    var cliente = clientes[i];

                    $("#pet_id_cliente").append("<option value='" + cliente.id + "'>" + cliente.nome + "</option>");

                }

            } else {
                //window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            //window.location = "Error";

        });
    },

    //Método para salvar pet
    SalvarPet: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Pet/Cadastrar",
            data: that.ViewModelCadastroPet,
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
        $("#message_sucess").addClass("d-none");
        $("#message_fail").addClass("d-none");
    },

    PosProcessSuccess: function () {
        $("#content_form_button").addClass("d-none");
        $("#content_form_message").removeClass("d-none");
        $("#content_form_loader").addClass("d-none");

        $("#message_sucess").removeClass("d-none");
        $("#message_fail").addClass("d-none");
    },

    PosProcessFail: function () {
        $("#content_form_button").removeClass("d-none");
        $("#content_form_message").removeClass("d-none");
        $("#content_form_loader").addClass("d-none");

        $("#message_sucess").addClass("d-none");
        $("#message_fail").removeClass("d-none");
    }


}