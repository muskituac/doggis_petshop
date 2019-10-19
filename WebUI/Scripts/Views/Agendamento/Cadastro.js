var Cadastro = {

    API_URL: "",
    UsuarioID: "",

    ViewModelCadastroAgendamento: new ViewModelCadastroAgendamento(),

    Initialize: function (api_url, usuario_id) {
        var that = this;

        that.API_URL = api_url;
        that.UsuarioID = usuario_id;


        $("#agendamento_cliente").focus();

        $("#agendamento_data_inicio").mask("00/00/0000");
        $("#agendamento_hora_inicio").mask("00:00");

        that.GetUsuario();
        that.GetClientes();
        that.GetServicos();

        //OnClick botão "Salvar"
        $("#btn_agendamento_salvar").on("click", function () {
            that.SalvarAgendamento();
        });

        //OnClick botão "Cancelar"
        $("#btn_agendamento_cancelar").on("click", function () {
            location.reload();
        });

        //OnChange select de clientes
        $("#agendamento_id_cliente").on("change", function () {
            that.GetPets();
        });

        $("#agendamento_id_servico").on("change", function () {
            that.BuscarFuncionario();
        });

    },

    //Método para inicializar objeto ViewModelLogin
    InitializeFormData: function () {
        var that = this;

        that.ViewModelCadastroAgendamento.cadastro_agendamento_id = $("#agendamento_id").val();
        that.ViewModelCadastroAgendamento.cadastro_agendamento_id_cliente = $("#agendamento_id_cliente").val();
        that.ViewModelCadastroAgendamento.cadastro_agendamento_id_pet = $("#agendamento_id_pet").val();
        that.ViewModelCadastroAgendamento.cadastro_agendamento_id_servico = $("#agendamento_id_servico").val();
        that.ViewModelCadastroAgendamento.cadastro_agendamento_id_funcionario = $("#agendamento_id_funcionario").val();
        that.ViewModelCadastroAgendamento.cadastro_agendamento_data_inicio = $("#agendamento_data_inicio").val() + " " + $("#agendamento_hora_inicio").val();
        that.ViewModelCadastroAgendamento.cadastro_agendamento_data_termino = $("#agendamento_data_inicio").val() + " " + $("#agendamento_hora_inicio").val();
        that.ViewModelCadastroAgendamento.cadastro_agendamento_notificacao_enviada = 0;
        that.ViewModelCadastroAgendamento.cadastro_agendamento_cancelamento = 0;
        that.ViewModelCadastroAgendamento.cadastro_agendamento_ultima_alteracao = $("#agendamento_ultima_alteracao").val();
        that.ViewModelCadastroAgendamento.cadastro_agendamento_responsavel = $("#agendamento_responsavel").val();
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

                $("#agendamento_responsavel").val(usuario.nome);

            } else {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para buscar todos os clientes
    GetClientes: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Cliente/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var clientes = response_done;

            if (clientes != "" && clientes != "undefined" && clientes != null) {

                for (var i = 0; i < clientes.length; i++) {

                    var cliente = clientes[i];
                    $("#agendamento_id_cliente").append("<option value='" + cliente.id + "'>" + cliente.nome + "</option>");

                }

            } else {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para buscar todos os pets de um determinado cliente
    GetPets: function () {
        var that = this;

        var cliente_id = $("#agendamento_id_cliente").val();

        if (cliente_id != "") {

            $("#content_agendamento_pet").html("<img src='../../Content/images/loader.gif'>");
            var element_agendamento_id_pet = "<select id='agendamento_id_pet' class='form-control'>";

            $.ajax({

                method: "GET",
                url: that.API_URL + "/Pet/GetPetByCliente?cliente_id=" + cliente_id,
                dataType: "json"

            }).done(function (response_done) {

                console.log("done: " + response_done);

                var pets = response_done;

                if (pets != "" && pets != "undefined" && pets != null) {

                    for (var i = 0; i < pets.length; i++) {

                        var pet = pets[i];
                        element_agendamento_id_pet += "<option value='" + pet.id + "' data-tipo-pet='" + pet.id_pet_tipo + "'>" + pet.nome + " (" + pet.pet_tipo.descricao + ")</option>";

                    }

                    element_agendamento_id_pet += "</select>";
                    $("#content_agendamento_pet").html(element_agendamento_id_pet);

                } else {
                    window.location = "Error";
                }
            }).fail(function (response_fail) {

                console.log("resposta fail: " + response_fail);
                window.location = "Error";

            });


        } else {
            $("#content_agendamento_pet").html("<label class='alert alert-info'>Selecione um cliente.</label>");
        }

    },

    //Método para buscar todos os servicos
    GetServicos: function () {
        var that = this;

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Servico/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var servicos = response_done;

            if (servicos != "" && servicos != "undefined" && servicos != null) {

                for (var i = 0; i < servicos.length; i++) {

                    var servico = servicos[i];
                    $("#agendamento_id_servico").append("<option value='" + servico.id + "' data-tipo-executante='" + servico.tipo_executante + "'>" + servico.nome + "</option>");

                }

            } else {
                window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            window.location = "Error";

        });
    },

    //Método para definir qual o tipo de funcionário irá listar
    BuscarFuncionario: function () {
        var that = this;

        var tipo_executante = 0;

        $("#agendamento_id_servico option:selected").each(function () {
            tipo_executante = $(this).attr("data-tipo-executante");
        });

        if (tipo_executante != "" && tipo_executante != 0 && tipo_executante != undefined) {
            if (tipo_executante == 1) {
                that.GetAtendentes();
            } else {
                that.GetVeterinarios();
            }
        } else {
            $("#content_agendamento_funcionario").html("<label class='alert alert-info'>Selecione um serviço.</label>");
        }


    },

    //Método para buscar todos os atendentes
    GetAtendentes: function () {
        var that = this;

        $("#content_agendamento_funcionario").html("<img src='../../Content/images/loader.gif'>");
        var element_agendamento_id_funcionario = "<select id='agendamento_id_funcionario' class='form-control'>";

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Atendente/GetAll",
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var atendentes = response_done;

            if (atendentes != "" && atendentes != "undefined" && atendentes != null) {

                for (var i = 0; i < atendentes.length; i++) {

                    var atendente = atendentes[i];
                    element_agendamento_id_funcionario += "<option value='" + atendente.id_funcionario + "'>" + atendente.nome + " (" + atendente.funcionario.nome + ")</option>";

                }

                element_agendamento_id_funcionario += "</select>";
                $("#content_agendamento_funcionario").html(element_agendamento_id_funcionario);

            } else {
               // window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            //window.location = "Error";

        });
    },

    //Método para buscar veterinários pelo tipo de pet
    GetVeterinarios: function () {
        var that = this;

        $("#content_agendamento_funcionario").html("<img src='../../Content/images/loader.gif'>");
        var element_agendamento_id_funcionario = "<select id='agendamento_id_funcionario' class='form-control'>";

        var pet_tipo_id = 0;
        $("#agendamento_id_pet option:selected").each(function () {
            pet_tipo_id = $(this).attr("data-tipo-pet");
        });

        $.ajax({

            method: "GET",
            url: that.API_URL + "/Veterinario/GetAllVeterinariosByPetTipo?pet_tipo_id=" + pet_tipo_id,
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            var veterinarios = response_done;

            if (veterinarios != "" && veterinarios != "undefined" && veterinarios != null) {

                for (var i = 0; i < veterinarios.length; i++) {

                    var veterinario = veterinarios[i];
                    element_agendamento_id_funcionario += "<option value='" + veterinario.id_funcionario + "'>" + veterinario.nome + " (" + veterinario.funcionario.nome + ")</option>";

                }

                element_agendamento_id_funcionario += "</select>";
                $("#content_agendamento_funcionario").html(element_agendamento_id_funcionario);

            } else {
                //window.location = "Error";
            }
        }).fail(function (response_fail) {

            console.log("resposta fail: " + response_fail);
            //window.location = "Error";

        });
    },

    //Método para salvar agendamento
    SalvarAgendamento: function () {
        var that = this;

        that.InitializeFormData();
        that.PreProcees();

        $.ajax({

            method: "POST",
            url: that.API_URL + "/Agendamento/Cadastrar",
            data: that.ViewModelCadastroAgendamento,
            dataType: "json"

        }).done(function (response_done) {

            console.log("done: " + response_done);

            if (response_done == 1) {
                that.PosProcessSuccess();
            } else if (response_done == 2) {
                that.PosProcessFailDetail();
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
        $("#message_fail_detail").addClass("d-none");
    },

    PosProcessSuccess: function () {
        $("#content_form_button").addClass("d-none");
        $("#content_form_message").removeClass("d-none");
        $("#content_form_loader").addClass("d-none");

        $("#message_success").removeClass("d-none");
        $("#message_fail").addClass("d-none");
        $("#message_fail_detail").addClass("d-none");
    },

    PosProcessFail: function () {
        $("#content_form_button").removeClass("d-none");
        $("#content_form_message").removeClass("d-none");
        $("#content_form_loader").addClass("d-none");

        $("#message_success").addClass("d-none");
        $("#message_fail").removeClass("d-none");
        $("#message_fail_detail").addClass("d-none");
    },

    PosProcessFailDetail: function () {
        $("#content_form_button").removeClass("d-none");
        $("#content_form_message").removeClass("d-none");
        $("#content_form_loader").addClass("d-none");

        $("#message_success").addClass("d-none");
        $("#message_fail").removeClass("d-none");
        $("#message_fail_detail").removeClass("d-none");
    }


}