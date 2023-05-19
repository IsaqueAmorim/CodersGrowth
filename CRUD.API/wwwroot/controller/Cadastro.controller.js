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
    const eloSeletorId = "campoElo";
    const dataSeletor = "campoData"
    const botaoSalvarId = "BotaoSalvar"

    const i18n_CadastroExistente = "Cadastro.Mensagem.Erro.Cadastro";
    const i18n_CadastroSucesso = "Cadastro.Mensagem.Sucesso.Cadastro";

    return Controller.extend("sap.ui.api.jogadores.controller.Cadastro",{
        
        onInit: function() {
            let JogadorModelo = new JSONModel({});
            this.getView().setModel(JogadorModelo,"jogador");

            const i18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();
           
            Validacao.obterI18n(i18n)

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
                   this.mostrarCaixaDeMensagem(i18n_CadastroSucesso,[MensagemDeTela.Action.OK],MensagemDeTela.success,true)
                   
                }else if(resposta.status === 400){
                    this.mostrarCaixaDeMensagem(i18n_CadastroExistente,[MensagemDeTela.Action.OK],MensagemDeTela.error,false)
                }
            });
        },
        mostrarCaixaDeMensagem: function(i18nMensagem,Acao,TipoMensagem,redirecionar){  
            let pacoteTraducoes = 
            this.getOwnerComponent()
            .getModel("i18n")
            .getResourceBundle()
            .getText(i18nMensagem);

            TipoMensagem(pacoteTraducoes,{
                actions: Acao,
                onClose : () => {       
                    if(redirecionar === true)   {
                        
                        this.aoClicarVoltar();
                    }       
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
        executarValidacao: function () {
       
            let botaoSalvar = this.obterCampo(botaoSalvarId);
            const inputs = this.obterInputsDaTela();

            if(Validacao.validarCampos(inputs)){
                botaoSalvar.setEnabled(true);
            }else{
                botaoSalvar.setEnabled(false);
            }

        },
        obterCampo: function (idCampo) {
            return this.getView().byId(idCampo);
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
           

        },
        obterInputsDaTela: function(){
            let nome = this.obterCampo(nomeIdInputId);
            let sobrenome = this.obterCampo(sobrenomeInputId);
            let apelido = this.obterCampo(apelidoInputId);
            let email = this.obterCampo(emailInputId);
            let elo = this.obterCampo(eloSeletorId);
            let dataNascimento = this.obterCampo(dataSeletor);
            

            return [
                {
                    input: nome,
                    tipo: Validacao.Tipos.TEXTO,
                    erro: Validacao.Erro.NOME
                },
                {
                    input: sobrenome,
                    tipo: Validacao.Tipos.TEXTO,
                    erro: Validacao.Erro.SOBRENOME
                },
                {
                    input: apelido,
                    tipo: Validacao.Tipos.TEXTO,
                    erro: Validacao.Erro.APELIDO
                },
                {
                    input: email,
                    tipo: Validacao.Tipos.EMAIL,
                    erro: Validacao.Erro.EMAIL
                },
                {
                    input: elo,
                    tipo: Validacao.Tipos.ELO,
                    erro: Validacao.Erro.ELO
                },
                {
                    input: dataNascimento,
                    tipo: Validacao.Tipos.NASCIMENTO,
                    erro: Validacao.Erro.NASCIMENTO
                }   
            ]
        }
    });
});