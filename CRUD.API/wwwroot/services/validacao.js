/* ================================================
============ SERVIÇO DE VALIDAÇÕES ===============*/
sap.ui.define([
    'sap/ui/core/library',
], function(Library) {
    'use strict';

    const i18n_NomeErro = "Cadastro.Mensagem.Erro.Nome";
    const i18n_SobrenomeErro = "Cadastro.Mensagem.Erro.Sobrenome";
    const i18n_EmailErro = "Cadastro.Mensagem.Erro.Email";
    const i18n_ApelidoErro = "Cadastro.Mensagem.Erro.Apelido";
    const i18n_EloErro = "Cadastro.Mensagem.Erro.Elo";
    const i18n_DataErro = "Cadastro.Mensagem.Erro.Data";

    let i18nLocal;
    
   
    
    return {
        
        validarCampos: function(array){

            let validado = [];
            
            array.forEach(campo => {
                
                

                if(this._validarIndividual(campo)){

                    campo.input.setValueStateText(i18nLocal.getText(campo.erro));
                    campo.input.setValueState(Library.ValueState.Error);
                    validado.push(false);
                }else{
                    campo.input.setValueState(Library.ValueState.None);
                    validado.push(true);
                }           
                
            });
           
            if(validado.includes(false)){ 
                return false;
            }else{
                return true;
            }
            
        },
        _validarEmail: function(email){

            const regex = /^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
        
            if(email.length === 0){
                return false
            }
            else if(regex.test(email)){
                return false
            }

            return true;
        },
        _validarTexto: function(texto){
        
            const regex = new RegExp("^[a-zA-Z\u00C0-\u017F´]+$")
            if(texto.length === 0){
               return false;
            }else if(regex.test(texto)){
                return false;
            }
            return true;
        },
        _validaElo(elo){
            const regex = new RegExp('^[0-8]+$');

            if(regex.test(elo)){
                return false;
            }
            return true;
        },
        _validarDataNascimento(data){  
            let dataConvertida = new Date(data)
            if(dataConvertida != "Invalid Date" && dataConvertida < new Date()) {
                return false;
            }
            return true;
        },
        _validarIndividual: function(campo){
            
            switch (campo.tipo) {

                case this.Tipos.TEXTO:
                    return this._validarTexto(campo.input.getValue());
                case this.Tipos.EMAIL:
                    return this._validarEmail(campo.input.getValue());
                case this.Tipos.NASCIMENTO:
                return this._validarDataNascimento(campo.input.getValue());
                case this.Tipos.ELO:
                    return this._validaElo(campo.input.getSelectedKey());
                    
            }
        },
        obterI18n: function(i18n){
            i18nLocal = i18n
            
        },
        Tipos:{
            TEXTO : 0,
            EMAIL: 1,
            ELO:2,
            NASCIMENTO:3
        },
        Erro:{
            NOME :i18n_NomeErro,
            SOBRENOME: i18n_SobrenomeErro,
            APELIDO:i18n_ApelidoErro,
            EMAIL:i18n_EmailErro,
            NASCIMENTO:i18n_DataErro,
            ELO : i18n_EloErro
        }
    }
});
