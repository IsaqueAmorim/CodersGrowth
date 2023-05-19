sap.ui.define([
  "sap/ui/core/mvc/Controller",
  "sap/ui/model/json/JSONModel",
  "sap/m/MessageBox",
  "sap/ui/core/routing/History",
  "../services/validacao",
  'sap/ui/core/library',
], function(Controller,JSONModel,MensagemDeTela,Historico, Validacao,Library) {
    'use strict';

    const nomeIdInputId = "campoNome";
    const sobrenomeInputId = "campoSobrenome";
    const apelidoInputId = "campoApelido";
    const emailInputId = "campoEmail";
    const eloSeletorId = "campoElo"
    const dataSeletor = "campoData"
    const botaoSalvarId = "BotaoSalvar"

    const i18n_NomeErro = "Cadastro.Mensagem.Erro.Nome";
    const i18n_SobrenomeErro = "Cadastro.Mensagem.Erro.Sobrenome";
    const i18n_EmailErro = "Cadastro.Mensagem.Erro.Email";
    const i18n_ApelidoErro = "Cadastro.Mensagem.Erro.Apelido";
    const i18n_EloErro = "Cadastro.Mensagem.Erro.Elo"
    const i18n_DataErro = "Cadastro.Mensagem.Erro.Data"


    

    return Controller.extend("sap.ui.api.jogadores.controller.Cadastro",{
        
        onInit: function() {
            let JogadorModelo = new JSONModel({});
            this.getView().setModel(JogadorModelo,"jogador");

            var rota = this.getOwnerComponent().getRouter();
           
            rota    
                .getRoute("cadastro")
                .attachMatched(this.aoCoincidirRotas, this);
        },
        abrirSeletorData: function(Evento){
            this.obterCampo(dataSeletor).openBy(Evento.getSource().getDomRef());
        },
        aoAlterar: function(Evento){
           let data = Evento.getParameter("value")
           this.obterCampo("BotaoData").data("text", data);
        },
        aoClicarSalvar: function(Event){
           
            let json = this.criarModelo();

            fetch("https://localhost:7139/v1/jogadores",
            {method:'POST',
            headers: {"Content-Type": "application/json"},
            body:JSON.stringify(json)})
            .then(resposta => {
                
                if(resposta.status === 201){
                   this.mostrarCaixaDeMensagem("Cadastro.MensagemSucesso")
                   
                }
            });
        },
        mostrarCaixaDeMensagem: function(i18nMensagem){  
            let pacoteTraducoes = 
            this.getOwnerComponent()
            .getModel("i18n")
            .getResourceBundle()
            .getText(i18nMensagem);

            MensagemDeTela.success(pacoteTraducoes,{
                actions: [MensagemDeTela.Action.OK],
                onClose : () => {                 
                   this.aoClicarVoltar();
                }
            });
        },
        aoCoincidirRotas: function(){

            this.limparCampos();
            this.limitarData();
            this.limparValidacao();
            this.obterCampo(botaoSalvarId).setEnabled(false);
            
        },
        aoClicarVoltar: function(){
            let historico = Historico.getInstance();
            let paginaAnterior = historico.getPreviousHash();

            if(paginaAnterior == undefined){
                let rota = this.getOwnerComponent().getRouter();
                rota.navTo("home");
            }else{
               
                window.history.go(-1);
            }
        },
        criarModelo: function(){
            let modelo = this.getView().getModel("jogador").getData();
            
            let json = {
                nome : modelo.nome,
                sobrenome:modelo.sobrenome,
                apelido: modelo.apelido,
                email:modelo.email,
                elo: parseInt(modelo.elo),
                dataNascimento: modelo.dataNascimento
            }

            return json;
                 
        },
        aoClicarCancelar: function() {

            let pacoteTraducoes = 
            this.getOwnerComponent()
            .getModel("i18n")
            .getResourceBundle()
            .getText("Cadastro.MensagemCancelar");

            MensagemDeTela.alert(pacoteTraducoes, {
                actions :[MensagemDeTela.Action.YES,MensagemDeTela.Action.NO],
                onClose : (acao) => {
                    if(acao == MensagemDeTela.Action.YES){
                        this.aoClicarVoltar();
                    }
                }
            });

            
        },
        limparCampos: function() {
            var nome = this.byId(nomeIdInputId);
            var sobrenome = this.byId(sobrenomeInputId);
            var apelido = this.byId(apelidoInputId);
            var email = this.byId(emailInputId);
            var elo = this.byId(eloSeletorId);
            var dataNascimento = this.byId(dataSeletor);
            nome?.setValue("");
            sobrenome?.setValue("");
            apelido?.setValue("");
            email?.setValue("");
            dataNascimento?.setValue("");
            elo?.setSelectedKey("");
        },
        limitarData: function() {
            let inputData = this.obterCampo(dataSeletor)
            inputData?.setMaxDate(new Date());
            inputData?.setMinDate(new Date(1950,1,1))
        },
        validarCampos: function () {
            let nome = this.obterCampo(nomeIdInputId);
            let sobrenome = this.obterCampo(sobrenomeInputId);
            let apelido = this.obterCampo(apelidoInputId);
            let email = this.obterCampo(emailInputId);
            let elo = this.obterCampo(eloSeletorId);
            let dataNascimento = this.obterCampo(dataSeletor);
            let botaoSalvar = this.obterCampo(botaoSalvarId);

           //Validando Nome
            let validacaoNome = this.exibirErroInput(
                nome,
                this.obterTexto(i18n_NomeErro),
                Validacao.validaCamposDeTexto(nome.getValue()));

            //Validando Sobrenome
            let validacaoSobrenome = this.exibirErroInput(
                sobrenome,
                this.obterTexto(i18n_SobrenomeErro),
                Validacao.validaCamposDeTexto(sobrenome.getValue()));

            //Validando Apelido
            let validacaoApelido = this.exibirErroInput(apelido,
                this.obterTexto(i18n_ApelidoErro),
                Validacao.validaCamposDeTexto(apelido.getValue()));

            //Validando Email
            let validacaoEmail = this.exibirErroInput(
                email,
                this.obterTexto(i18n_EmailErro),
                Validacao.validaEmail(email.getValue()));

            //Validando Elo
            let validacaoElo = this.exibirErroInput(
                elo,
                this.obterTexto(i18n_EloErro),
                Validacao.validaElo(elo.getSelectedKey()));

            //Validando Data
            let validacaoData = this.exibirErroInput(dataNascimento,
            this.obterTexto(i18n_DataErro),
            Validacao.validaDataNascimento(dataNascimento.getValue()));
            
            if(
                validacaoNome && 
                validacaoSobrenome && 
                validacaoApelido && 
                validacaoElo && 
                validacaoEmail &&
                validacaoData
            ){
                botaoSalvar.setEnabled(true);
            }else{
                botaoSalvar.setEnabled(false);
            }

        },
        obterCampo: function (idCampo) {
            return this.getView().byId(idCampo);
        },
        exibirErroInput: function (campo,mensagemErro,bool) {
            if(bool){
                campo.setValueStateText(mensagemErro);
                campo.setValueState(Library.ValueState.Error);
                return false;
            }else{
                campo.setValueState(Library.ValueState.None);
                return true;
            }
        },
        obterTexto: function(i18nMensagem) {
            
            return this.getOwnerComponent()
            .getModel("i18n")
            .getResourceBundle()
            .getText(i18nMensagem);
        },
        limparValidacao: function () {
            let nome = this.obterCampo(nomeIdInputId);
            let sobrenome = this.obterCampo(sobrenomeInputId);
            let apelido = this.obterCampo(apelidoInputId);
            let email = this.obterCampo(emailInputId);
            let elo = this.obterCampo(eloSeletorId);
            let dataNascimento = this.obterCampo(dataSeletor);
       
            nome.setValueState(Library.ValueState.None);
            sobrenome.setValueState(Library.ValueState.None);
            apelido.setValueState(Library.ValueState.None);
            email.setValueState(Library.ValueState.None);
            elo.setValueState(Library.ValueState.None);
            dataNascimento.setValueState(Library.ValueState.None);
           

        }
    });
});