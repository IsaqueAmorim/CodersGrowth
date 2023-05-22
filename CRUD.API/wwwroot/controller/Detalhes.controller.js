sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/formatter",
    "sap/ui/model/json/JSONModel",
    "../controller/ControllerBase",
    "sap/m/MessageBox",
    "../repositorios/Repositorio"
    
], function(Controller, Formatador,JSONModel,ControllerBase,MessageBox,Repo) {
    'use strict';
    
    const rotaHome = "home";
    const campoId = "campoId";

 
    const enderecoController = "sap.ui.api.jogadores.controller.Detalhes";
    return Controller.extend(enderecoController,{

        formatter: Formatador,
        onInit: function() {
            const rotaDetalhes = "detalhes";

            var rota = this.getOwnerComponent().getRouter();
            rota.getRoute(rotaDetalhes).attachMatched(this._aoCoincidirRota, this);
        },
        _aoCoincidirRota: function (evento) {
            
            const parametroArguments = "arguments";
            
            var id = evento.getParameter(parametroArguments).id;
            this._obterDados(id);
        },
        _obterDados: async function(id){

            const resposta = await Repo.obterPorId(id);
		    this.getView().setModel(new JSONModel({jogador: resposta}));
		},
        aoClicarVoltar: function(){
            
            let rota = this.getOwnerComponent().getRouter();
           ControllerBase.aoClicarVoltar(rota);
        },
        aoClicarEditar: function (){

            const rotaEdicao = "edicao";
 
            let rota = this.getOwnerComponent().getRouter();
            let idJogador = this.getView().byId(campoId).getValue();
			rota.navTo(rotaEdicao, {id: idJogador});
        },
        aoClicarDeletar: function (){
            const i18n_mensagemConfirmarDeletar = "Detalhes.Mensagem.Confirmar.Remover";

            this._mostrarMensagem(
                i18n_mensagemConfirmarDeletar,
                [MessageBox.Action.YES,MessageBox.Action.NO],
                MessageBox.warning
            )
        
        },
        _mostrarMensagem: async function(i18nMensagem,Acao,TipoMensagem){ 

            const i18n_mensagemDeletado = "Detalhes.Mensagem.Sucesso.Deletar";
            const i18n_mensagemFalahaDeletar = "Detalhes.Mensagem.Erro.Deletar";
            const codigoNoContent = 204;
            
            let rota = this.getOwnerComponent().getRouter();
            let idJogador = this.getView().byId(campoId).getValue();
            
            TipoMensagem(this._obterTraducao(i18nMensagem),{
                actions: Acao,
                
                onClose :async  (acao) => {     

                    if(acao === MessageBox.Action.YES){

                        const resposta = await Repo.deletar(idJogador)

                        if(resposta == codigoNoContent){

                            MessageBox.success(this._obterTraducao(i18n_mensagemDeletado),{
                                actions: [MessageBox.Action.OK],
                                onClose: function(){
                                   rota.navTo(rotaHome)
                                }
                            })

                        }else{
                            MessageBox.error(this._obterTraducao(i18n_mensagemFalahaDeletar),{
                                actions: [MessageBox.Action.OK],
                                onClose: function(){
                                   
                                }
                            })
                        }       
                    }
                }   
            })                        
        },
        _obterTraducao: function(i18nMensagem){

            const i18n_ptBR = "i18n";

            let pacoteTraducoes = 
            this.getOwnerComponent()
            .getModel(i18n_ptBR)
            .getResourceBundle()
            .getText(i18nMensagem);

            return pacoteTraducoes;

            

        }
    })
});