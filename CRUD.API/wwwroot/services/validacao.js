/* ================================================
============ SERVIÇO DE VALIDAÇÕES ===============*/
sap.ui.define([], function() {
    'use strict';
    
    return {
        validaEmail: function(email){

            let regex = /\S+@\S+\.\S+/;
        
            if(email.length === 0){
                return false
            }
            else if(regex.test(email)){
                return false
            }

            return true;
        },
        validaCamposDeTexto: function(texto){
        
            let regex = new RegExp("^[a-zA-Z\u00C0-\u017F´]+$")
            if(texto.length === 0){
                return "O campo não pode ser vazio!"
            }else if(regex.test(texto)){
                return "Digite apenas uma palavra, sem numeros e sem caracteres especiais"
            }
        },
        teste: function(){
            this.getView().
        }
        
    }
});
