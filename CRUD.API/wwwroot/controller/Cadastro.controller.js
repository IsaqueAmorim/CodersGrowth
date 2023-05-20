    sap.ui.define([
  "sap/ui/core/mvc/Controller",
  "sap/ui/model/json/JSONModel",
  "sap/m/MessageBox",
  "sap/ui/core/routing/History",
  "../services/validacao",
  'sap/ui/core/library',
  "../repositorios/Repositorio"
], function(Controller,JSONModel,MensagemDeTela,Historico, Validacao,Library,Repo) {
    'use strict';

    // ======== CAMPOS ============
    const nomeInputId = "campoNome";
    const sobrenomeInputId = "campoSobrenome";
    const apelidoInputId = "campoApelido";
    const emailInputId = "campoEmail";
    const eloSeletorId = "campoElo";
    const dataSeletor = "campoData"
    const dataBotao = "botaoData"
    const botaoSalvarId = "BotaoSalvar"

    // ============ TRADUÇÕES ============
    const i18n_CadastroExistente = "Cadastro.Mensagem.Erro.Cadastro";
    const i18n_CadastroSucesso = "Cadastro.Mensagem.Sucesso.Cadastro";
    const i18n_MensagemConfirmarCancelar = "Cadastro.MensagemCancelar"

    // ============= ROTAS ==============
    const rotaHome = "home";
    const rotaEdicao = "edicao";
    const rotaDetalhes = "detalhes";
    const rotaCadastro = "cadastro";

    // =============== CÓDIGOS ===========
    const codigoOK = 200;
    const codigoNoContent = 204;
    const codigoFalhaNaRequisicao = 400;
    const codigoCriado = 201;

    let operacao;
    let idJogador;

    return Controller.extend("sap.ui.api.jogadores.controller.Cadastro",{
        
        onInit: function() {
            let JogadorModelo = new JSONModel({});
            this.getView().setModel(JogadorModelo,"jogador");

            const i18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();
           
            Validacao.obterI18n(i18n)

            let rota = this.getOwnerComponent().getRouter();
           
            rota    
                .getRoute(rotaCadastro)
                .attachMatched(this.aoCoincidirRotaCadastro, this);

            rota    
            .getRoute(rotaEdicao)
            .attachMatched(this.aoCoincidirRotaEdicao, this)

        },
        abrirSeletorData: function(Evento){
            this._obterCampo(dataSeletor).openBy(Evento.getSource().getDomRef());
            },
        aoAlterar: function(Evento){
           let data = Evento.getParameter("value")
           this._obterCampo(dataBotao).data("text", data);
        },
        aoClicarSalvar: async function(){

            if(operacao == this.Operacao.CADASTRAR){
                let json = this.criarModelo();

                debugger
                let resposta = await Repo.criar(json);

                if(resposta === codigoCriado){

                    this.mostrarCaixaDeMensagem(

                        i18n_CadastroSucesso,
                        [MensagemDeTela.Action.OK],
                        MensagemDeTela.success,true)
                    
                    }else{

                        this.mostrarCaixaDeMensagem(

                            i18n_CadastroExistente,
                            [MensagemDeTela.Action.OK],
                            MensagemDeTela.error,false)
                    }

            }else if(operacao == this.Operacao.EDITAR){
                let jogadorAtualizado = this.criarModelo();
                
                const resposta = await Repo.atualizar(jogadorAtualizado,idJogador);

                if(resposta === codigoOK){
                    this.mostrarCaixaDeMensagem(
                        i18n_CadastroSucesso,
                        [MensagemDeTela.Action.OK],
                        MensagemDeTela.success,true)
            
                }else{
                    this.mostrarCaixaDeMensagem(
                    i18n_CadastroExistente,
                    [MensagemDeTela.Action.OK],
                    MensagemDeTela.error,false)
                }
            }
            
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
                        
                        let rota = this.getOwnerComponent().getRouter();
                        rota.navTo(rotaHome);
                    }       
                }
            });
        },
        aoCoincidirRotaCadastro: function(){

            this.limparCampos();
            this.limitarData();
            this._limparValidacao();
            this._obterCampo(botaoSalvarId).setEnabled(false);
            operacao = this.Operacao.CADASTRAR;
            
        },
        aoCoincidirRotaEdicao: async function (evento){
            
            var id = evento.getParameter("arguments").id;
            let dadosJogador = await this.obterDados(id);     
            this.preencherFormulario(dadosJogador);
            operacao = this.Operacao.EDITAR;
            idJogador = id;
            this.definirComoEditavel();

            
        },
        aoClicarVoltar: function(){
            let historico = Historico.getInstance();
            let paginaAnterior = historico.getPreviousHash();

            if(paginaAnterior == undefined){
                let rota = this.getOwnerComponent().getRouter();
                rota.navTo(rotaHome);
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

            const mensagem = this._obterTraducao(i18n_MensagemConfirmarCancelar);

            MensagemDeTela.alert(mensagem, {
                actions :[MensagemDeTela.Action.YES,MensagemDeTela.Action.NO],
                onClose : (acao) => {
                    if(acao == MensagemDeTela.Action.YES){
                        this.aoClicarVoltar();
                    }
                }
            });

            
        },
        limparCampos: function() {
            
            const campo = this.obterCampos();
            campo.nome?.setValue("");
            campo.sobrenome?.setValue("");
            campo.apelido?.setValue("");
            campo.email?.setValue("");
            campo.dataNascimento?.setValue("");
            campo.elo?.setSelectedKey("");
        },
        limitarData: function() {
            let inputData = this._obterCampo(dataSeletor)
            inputData?.setMaxDate(new Date());
            inputData?.setMinDate(new Date(1950,1,1))
        },
        executarValidacao: function () {
       
            let botaoSalvar = this._obterCampo(botaoSalvarId);
            const inputs = this._definirDadosParaValidar();

            if(Validacao.validarCampos(inputs)){
                botaoSalvar.setEnabled(true);
            }else{
                botaoSalvar.setEnabled(false);
            }

        },
        _obterCampo: function (idCampo) {
            return this.getView().byId(idCampo);
        },
        _obterTraducao: function(i18nMensagem) {
            
            return this.getOwnerComponent()
            .getModel("i18n")
            .getResourceBundle()
            .getText(i18nMensagem);
        },
        _limparValidacao: function () {
           
            const campo = this.obterCampos();
       
            campo.nome.setValueState(Library.ValueState.None);
            campo.sobrenome.setValueState(Library.ValueState.None);
            campo.apelido.setValueState(Library.ValueState.None);
            campo.email.setValueState(Library.ValueState.None);
            campo.elo.setValueState(Library.ValueState.None);
            campo.dataNascimento.setValueState(Library.ValueState.None);
           

        },
        _definirDadosParaValidar: function(){
            let data = this.obterCampos();
            

            return [
                {
                    input: data.nome,
                    tipo: Validacao.Tipos.TEXTO,
                    erro: Validacao.Erro.NOME
                },
                {
                    input: data.sobrenome,
                    tipo: Validacao.Tipos.TEXTO,
                    erro: Validacao.Erro.SOBRENOME
                },
                {
                    input: data.apelido,
                    tipo: Validacao.Tipos.TEXTO,
                    erro: Validacao.Erro.APELIDO
                },
                {
                    input: data.email,
                    tipo: Validacao.Tipos.EMAIL,
                    erro: Validacao.Erro.EMAIL
                },
                {
                    input: data.elo,
                    tipo: Validacao.Tipos.ELO,
                    erro: Validacao.Erro.ELO
                },
                {
                    input: data.dataNascimento,
                    tipo: Validacao.Tipos.NASCIMENTO,
                    erro: Validacao.Erro.NASCIMENTO
                }   
            ]
        },
        obterDados: async function(id){

            const resposta = await Repo.obterPorId(id);
		    return resposta;
                
        },
        preencherFormulario: function(dadosJogador){
            
            let dados = this.obterCampos();
            
            dados.nome.setValue(dadosJogador.nome);
            dados.sobrenome.setValue(dadosJogador.sobrenome);
            dados.apelido.setValue(dadosJogador.apelido);
            dados.email.setValue(dadosJogador.email);
            dados.elo.setSelectedKey(dadosJogador.elo.toString());
            dados.dataNascimento.setValue(dadosJogador.dataNascimento);

        },
        definirComoEditavel: function(){
            let inputs = this.obterCampos();

            inputs.nome.setEnabled(true);
            inputs.sobrenome.setEnabled(true);
            inputs.email.setEnabled(true);
            inputs.apelido.setEnabled(true);
            inputs.elo.setEnabled(true);
            inputs.dataNascimento.setEnabled(true);
        },
        obterCampos: function(){
            let nome = this._obterCampo(nomeInputId);
            let sobrenome = this._obterCampo(sobrenomeInputId);
            let apelido = this._obterCampo(apelidoInputId);
            let email = this._obterCampo(emailInputId);
            let elo = this._obterCampo(eloSeletorId);
            let dataNascimento = this._obterCampo(dataSeletor);

            return {
                nome: nome,
                sobrenome: sobrenome,
                apelido: apelido,
                email: email,
                elo: elo,
                dataNascimento: dataNascimento
            }
        },
        Operacao:{
            CADASTRAR:0,
            EDITAR:1
        }

    });
});