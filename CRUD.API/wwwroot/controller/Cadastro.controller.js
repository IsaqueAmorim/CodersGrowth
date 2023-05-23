    sap.ui.define([
  "sap/ui/core/mvc/Controller",
  "sap/ui/model/json/JSONModel",
  "sap/m/MessageBox",
  "../controller/ControllerBase",
  "../services/validacao",
  'sap/ui/core/library',
  "../repositorios/Repositorio"
], function(Controller,JSONModel,MensagemDeTela,ControllerBase, Validacao,Library,Repo) {
    'use strict';

    const dataSeletor = "campoData"
    let operacao;
    let idJogador;

    const enderecoController = "sap.ui.api.jogadores.controller.Cadastro";

    return Controller.extend(enderecoController,{
        
        onInit: function() {

            const nomeJogadorModel = "jogador";
            const arquivoI18n = "i18n";
            const rotaEdicao = "edicao";
            const rotaCadastro = "cadastro";

            let JogadorModelo = new JSONModel({});
            this.getView().setModel(JogadorModelo,nomeJogadorModel);

            const i18n = this.getOwnerComponent().getModel(arquivoI18n).getResourceBundle();
            Validacao.obterI18n(i18n)

            let rota = this.getOwnerComponent().getRouter();
           
            rota    
                .getRoute(rotaCadastro)
                .attachMatched(this._aoCoincidirRotaCadastro, this);

            rota    
            .getRoute(rotaEdicao)
            .attachMatched(this._aoCoincidirRotaEdicao, this)

        },
        abrirSeletorData: function(Evento){
            this._obterCampo(dataSeletor).openBy(Evento.getSource().getDomRef());
            },
        aoAlterar: function(Evento){
           ControllerBase.processarEvento(() => {
               
               const dataBotao = "botaoData"
               const parametroValue = "value"
               const propriedadeText = "text"
    
              let data = Evento.getParameter(parametroValue);
              this._obterCampo(dataBotao).data(propriedadeText, data);
           })
        },
        aoClicarSalvar: async function(){
            ControllerBase.processarEvento(async () => {

                if(operacao == this.Operacao.CADASTRAR){
                    const i18n_CadastroExistente = "Cadastro.Mensagem.Erro.Cadastro";
                    const i18n_CadastroSucesso = "Cadastro.Mensagem.Sucesso.Cadastro";
                    const codigoCriado = 201;
                    
                    let json = this._criarModelo();
    
                    let resposta = await Repo.criar(json);
                    if(resposta === codigoCriado){
    
                        this._mostrarMensagem(
    
                            i18n_CadastroSucesso,
                            [MensagemDeTela.Action.OK],
                            MensagemDeTela.success,true)
                        
                        }else{
    
                            this._mostrarMensagem(
    
                                i18n_CadastroExistente,
                                [MensagemDeTela.Action.OK],
                                MensagemDeTela.error,false)
                        }
    
                }else if(operacao == this.Operacao.EDITAR){
    
                    const i18n_MensagemSucessoEditar = "Cadastro.Mensagem.Sucesso.Editado";
                    const i18n_MensagemErroEditar = "Cadastro.Mensagem.Erro.Editar";
                    const codigoNoContent = 204;
                    
                    let jogadorAtualizado = this._criarModelo();
                    const resposta = await Repo.atualizar(jogadorAtualizado,idJogador);
                
                    if(resposta === codigoNoContent){
                        this._mostrarMensagem(
                            i18n_MensagemSucessoEditar,
                            [MensagemDeTela.Action.OK],
                            MensagemDeTela.success,true)
                
                    }else{
                        this._mostrarMensagem(
                        i18n_MensagemErroEditar,
                        [MensagemDeTela.Action.OK],
                        MensagemDeTela.error,false)
                    }
                }
            })
            
            
        },
        _mostrarMensagem: function(i18nMensagem,Acao,TipoMensagem,redirecionar){  
            const rotaHome = "home";

            let pacoteTraducoes = _obterTraducaoTraducao(i18nMensagem);

            TipoMensagem(pacoteTraducoes,{
                actions: Acao,
                onClose : () => {       
                    if(redirecionar === true)   {
                        
                        let rota = this.getOwnerComponent().getRouter();
                        //Trocar para voltar a detalhes!
                        rota.navTo(rotaHome);
                    }       
                }
            });
        },
        _aoCoincidirRotaCadastro: function(){
            ControllerBase.processarEvento(() =>{
                const botaoSalvarId = "BotaoSalvar"

                this._limparCampos();
                this._limitarData();
                this._limparValidacao();
                this._obterCampo(botaoSalvarId).setEnabled(false);
                operacao = this.Operacao.CADASTRAR;
            })
            
            
        },
        _aoCoincidirRotaEdicao: async function (evento){
            
            ControllerBase.processarEvento(async ()=>{

                const argumentoDoParametro = "arguments";
    
                var id = evento.getParameter(argumentoDoParametro).id;
                let dadosJogador = await this._obterDados(id);     
                this._preencherFormulario(dadosJogador);
                operacao = this.Operacao.EDITAR;
                idJogador = id;
            })
            
        },
        aoClicarVoltar: function(){
            ControllerBase.processarEvento(()=>{

                const rota = this.getOwnerComponent().getRouter();
                ControllerBase.navegarParaPaginaAnterior(rota);
            })
        },
        _criarModelo: function(){
            const modeloJogador = "jogador"

            let modelo = this.getView().getModel(modeloJogador).getData();
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
            ControllerBase.processarEvento(()=>{

                const i18n_MensagemConfirmarCancelar = "Cadastro.MensagemCancelar"
                const mensagem = this._obterTraducao(i18n_MensagemConfirmarCancelar);
    
                MensagemDeTela.alert(mensagem, {
                    actions :[MensagemDeTela.Action.YES,MensagemDeTela.Action.NO],
                    onClose : (acao) => {
                        if(acao == MensagemDeTela.Action.YES){
                            this.aoClicarVoltar();
                        }
                    }
                });
            })

            
        },
        _limparCampos: function() {
            
            const campoVazio = "";
            const campo = this._obterCampos();

            campo.nome?.setValue(campoVazio);
            campo.sobrenome?.setValue(campoVazio);
            campo.apelido?.setValue(campoVazio);
            campo.email?.setValue(campoVazio);
            campo.dataNascimento?.setValue(campoVazio);
            campo.elo?.setSelectedKey(campoVazio);
        },
        _limitarData: function() {
            let inputData = this._obterCampo(dataSeletor)
            inputData?.setMaxDate(new Date());
            inputData?.setMinDate(new Date(1950,1,1))
        },
        executarValidacao: function () {
            
            const botaoSalvarId = "BotaoSalvar"
       
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
            return ControllerBase.obterTraducao(i18nMensagem);
        },
        _limparValidacao: function () {
           
            const campo = this._obterCampos();
       
            campo.nome.setValueState(Library.ValueState.None);
            campo.sobrenome.setValueState(Library.ValueState.None);
            campo.apelido.setValueState(Library.ValueState.None);
            campo.email.setValueState(Library.ValueState.None);
            campo.elo.setValueState(Library.ValueState.None);
            campo.dataNascimento.setValueState(Library.ValueState.None);
           

        },
        _definirDadosParaValidar: function(){
            let data = this._obterCampos();

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
                    input: data.dataNascimento,
                    tipo: Validacao.Tipos.NASCIMENTO,
                    erro: Validacao.Erro.NASCIMENTO
                },
                {
                    input: data.elo,
                    tipo: Validacao.Tipos.ELO,
                    erro: Validacao.Erro.ELO
                } 
            ]
        },
        _obterDados: async function(id){

            const resposta = await Repo.obterPorId(id);
		    return resposta;
                
        },
        _preencherFormulario: function(dadosJogador){
            
            let dados = this._obterCampos();
            
            dados.nome.setValue(dadosJogador.nome);
            dados.sobrenome.setValue(dadosJogador.sobrenome);
            dados.apelido.setValue(dadosJogador.apelido);
            dados.email.setValue(dadosJogador.email);
            dados.elo.setSelectedKey(dadosJogador.elo.toString());
            dados.dataNascimento.setValue(dadosJogador.dataNascimento);

        },
        _obterCampos: function(){
            const nomeInputId = "campoNome";
            const sobrenomeInputId = "campoSobrenome";
            const apelidoInputId = "campoApelido";
            const emailInputId = "campoEmail";
            const eloSeletorId = "campoElo";
            
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
        },         
    });
});