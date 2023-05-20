sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "../model/formatter",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator",
	"sap/ui/model/json/JSONModel",
	"../repositorios/Repositorio"
 ], function (Controller,formatter,Filter,FilterOperator,JSONModel,Repo) {
    "use strict";

	// ======== ROTAS ==========
	const rotaDetalhes = "detalhes";
    const rotaEdicao = "edicao";
    const rotaHome = "home";
	const rotaCadastro = "cadastro";

	const idLinha = "id";

    return Controller.extend("sap.ui.api.jogadores.controller.TelaListaDeJogadores", {
        formatter : formatter,
        _aoDigitar: function (oEvent) {
			
			let filtro = [];
			let buscar = oEvent.getParameter("query");
			if(buscar){
				filtro.push(new Filter("nome", FilterOperator.Contains, buscar));
			}

			let tabela = this.byId("tabela_jogadores")
			let items = tabela.getBinding("items");
			items.filter(filtro);
			
		},
		onInit : function(){

			this._obterDados();
			let rota = this.getOwnerComponent().getRouter();
           
            rota    
            .getRoute(rotaHome)
            .attachMatched(this._aoCoincidirRota, this);

		},
		_obterDados: async function(){
			
			const resposta = await Repo.obterTodos();
			this.getView().setModel(new JSONModel({jogadores: resposta}));

		},
		aoClicarNaLinha : function (EventoDeClique){
			let rota = this.getOwnerComponent().getRouter();
			let idDaLinha = EventoDeClique.getSource().getBindingContext().getProperty(idLinha);
			rota.navTo(rotaDetalhes, {id: idDaLinha});
		},
		aoClicarEmAdicionar: function(){
			let rota = this.getOwnerComponent().getRouter();
			rota.navTo(rotaCadastro)
		},
		_aoCoincidirRota: function(){
			this._obterDados();
		}
    });
 });
 
