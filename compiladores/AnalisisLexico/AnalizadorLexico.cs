﻿using Compilador_22023.cache;
using Compilador_22023.GestorErrores;
using Compilador_22023.TablaComponentes;
using Compilador_22023.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_22023.AnalisisLexico
{
    public class AnalizadorLexico
    {
        private string contenidoLineaActual = "";
        private int numeroLineaActual = 0;
        private int puntero = 0;
        private string caracterActual= "";
        private string lexema = "";
        private CategoriaGramatical categoria = CategoriaGramatical.DEFECTO;
        private string estadoActual = "q0";
        private int posicionInicial = 0;
        private bool continuarAnalisis = false;
        private ComponenteLexico componente = null;
        private string falla = "";
        private string causa = "";
        private string solucion = "";

        public AnalizadorLexico()
        {
            CargarNuevaLinea();
        }

        private void CargarNuevaLinea()
        {
            if (!"@EOF@".Equals(contenidoLineaActual))
            {
                numeroLineaActual = numeroLineaActual +1;
                contenidoLineaActual = DataCache.ObtenerLinea(numeroLineaActual).Contenido;
                numeroLineaActual = DataCache.ObtenerLinea(numeroLineaActual).NumeroLinea;
                puntero = 1;
            }
        
        }
        private void LeerSiguienteCaracter()
        {

            if("@EOF@".Equals(contenidoLineaActual)) {
                caracterActual = "@EOF@";
            }else if(puntero > contenidoLineaActual.Length)
            {
                caracterActual = "@FL@";
            }
            else
            {
                caracterActual = contenidoLineaActual.Substring(puntero - 1, 1);
                puntero = puntero + 1;
            }

        }
        private void DevolverPuntero()
        {
            if (!"@FL@".Equals(caracterActual))
            {
                puntero = puntero - 1;
            }

        }
        private void Concatenar()
        {

            lexema = lexema + caracterActual;

        }
        private void Resetear()
        {

            estadoActual = "q0";
            lexema = "";
            categoria = CategoriaGramatical.DEFECTO;
            posicionInicial = 0;
            continuarAnalisis = true;
            componente = null;
    }
    public ComponenteLexico DevolverSiguienteComponente()
        {

            Resetear();
            while (continuarAnalisis)
            {
                if ("q0".Equals(estadoActual))
                {
                    ProcesarEstado0();
                }
                else if ("q1".Equals(estadoActual))
                {
                    ProcesarEstado1();
                }
                else if ("q2".Equals(estadoActual))
                {
                    ProcesarEstado2();
                }
                else if ("q3".Equals(estadoActual))
                {
                    ProcesarEstado3();
                }
                else if ("q4".Equals(estadoActual))
                {
                    ProcesarEstado4();
                }
                else if ("q5".Equals(estadoActual))
                {
                    ProcesarEstado5();
                }
                else if ("q6".Equals(estadoActual))
                {
                    ProcesarEstado6();
                }
                else if ("q7".Equals(estadoActual))
                {
                    ProcesarEstado7();
                }
                else if ("q8".Equals(estadoActual))
                {
                    ProcesarEstado8();
                }
                else if ("q9".Equals(estadoActual))
                {
                    ProcesarEstado9();
                }
                else if ("q10".Equals(estadoActual))
                {
                    ProcesarEstado10();
                }
                else if ("q11".Equals(estadoActual))
                {
                    ProcesarEstado11();
                }
                else if ("q12".Equals(estadoActual))
                {
                    ProcesarEstado12();
                }
                else if ("q13".Equals(estadoActual))
                {
                    ProcesarEstado13();
                }
                else if ("q14".Equals(estadoActual))
                {
                    ProcesarEstado14();
                }
                else if ("q15".Equals(estadoActual))
                {
                    ProcesarEstado15();
                }
                else if ("q16".Equals(estadoActual))
                {
                    ProcesarEstado16();
                }
                else if ("q17".Equals(estadoActual))
                {
                    ProcesarEstado17();
                }
                else if ("q18".Equals(estadoActual))
                {
                    ProcesarEstado18();
                }
                else if ("q19".Equals(estadoActual))
                {
                    ProcesarEstado19();
                }
                else if ("q33".Equals(estadoActual))
                {
                    ProcesarEstado33();
                }
                else if ("q34".Equals(estadoActual))
                {
                    ProcesarEstado34();
                }
                else if ("q35".Equals(estadoActual))
                {
                    ProcesarEstado35();
                }
                else if ("q36".Equals(estadoActual))
                {
                    ProcesarEstado36();
                }
            }
            TablaMaestra.ObtenerTablaMaestra().Agregar(componente);
            return componente;

        }

        private void ProcesarEstado0()
        {
            DevorarEspaciosEnBlanco();

            if (UtilTexto.EsLetra(caracterActual) || UtilTexto.EsSignoPesos(caracterActual) || UtilTexto.EsGuionBajo(caracterActual))
            {
                estadoActual = "q4";
            }
            else if ((UtilTexto.EsDigito(caracterActual)))
            {
                estadoActual = "q1";
            }
            else if (UtilTexto.EsSignoSuma(caracterActual))
            {
                estadoActual = "q5";
            }
            else if (UtilTexto.EsSignoResta(caracterActual))
            {
                estadoActual = "q6";
            }
            else if (UtilTexto.EsSignoAsterisco(caracterActual))
            {
                estadoActual = "q7";
            }
            else if (UtilTexto.EsSignoSlash(caracterActual))
            {
                estadoActual = "q8";
            }
            else if (UtilTexto.EsSignoPorcentaje(caracterActual))
            {
                estadoActual = "q9";
            }
            else if (UtilTexto.EsSignoParentesisA(caracterActual))
            {
                estadoActual = "q10";
            }
            else if (UtilTexto.EsSignoParentesisC(caracterActual))
            {
                estadoActual = "q11";
            }
            else if ((UtilTexto.EsEOF(caracterActual)))
            {
                estadoActual = "q12";
            }
            else if ((UtilTexto.EsFL(caracterActual)))
            {
                estadoActual = "q13";
            }
            else if ((UtilTexto.EsSignoIgual(caracterActual)))
            {
                estadoActual = "q19";
            }
            else
            {
                estadoActual = "q18";
            }
        }
        private void ProcesarEstado1()
        {
            Concatenar();
            LeerSiguienteCaracter();

            if (UtilTexto.EsDigito(caracterActual))
            {
                estadoActual = "q1";
            }else if (UtilTexto.EsComa(caracterActual))
            {
                estadoActual = "q2";
            }
            else
            {
                estadoActual = "q14";
            }

        }

        private void ProcesarEstado2()
        {
            Concatenar();
            LeerSiguienteCaracter();

            if (UtilTexto.EsDigito(caracterActual))
            {
                estadoActual = "q3";
            }
            else
            {
                estadoActual = "q17";
            }
        }
        private void ProcesarEstado3()
        {
            Concatenar();
            LeerSiguienteCaracter();

            if (UtilTexto.EsLetraDigito(caracterActual))
            {
                estadoActual = "q3";
            }
            else
            {
                estadoActual = "q15";
            }
        }
        private void ProcesarEstado4()
        {
            Concatenar();
            LeerSiguienteCaracter();
            if (UtilTexto.EsLetra(caracterActual) || UtilTexto.EsLetraDigito(caracterActual) || UtilTexto.EsSignoPesos(caracterActual) || UtilTexto.EsGuionBajo(caracterActual))
            {
                estadoActual = "q4";
            }
            else
            {
                estadoActual = "q16";
            }

        }
        private void ProcesarEstado5()
        {
            lexema = caracterActual;
            categoria = CategoriaGramatical.SUMA;
            FormarComponenteLexicoLiteral();
            continuarAnalisis = false;

        }
        private void ProcesarEstado6()
        {
            lexema = caracterActual;
            categoria = CategoriaGramatical.RESTA;
            FormarComponenteLexicoLiteral();
            continuarAnalisis = false;

        }
        private void ProcesarEstado7()
        {
            lexema = caracterActual;
            categoria = CategoriaGramatical.MULTIPLICACION;
            FormarComponenteLexicoLiteral();
            continuarAnalisis = false;

        }
        private void ProcesarEstado8()
        {
            LeerSiguienteCaracter();
            if (UtilTexto.EsSignoAsterisco(caracterActual)){
                estadoActual = "q34";
            }else if (UtilTexto.EsSignoSlash(caracterActual))
            {
                estadoActual = "q36";
            }
            else
            {
                estadoActual = "q33";
            }

        }
        private void ProcesarEstado9()
        {
            lexema = caracterActual;
            categoria = CategoriaGramatical.MODULO;
            FormarComponenteLexicoLiteral();
            continuarAnalisis = false;
        }
        private void ProcesarEstado10()
        {
            lexema = caracterActual;
            categoria = CategoriaGramatical.PARENTESIS_ABRE;
            FormarComponenteLexicoLiteral();
            continuarAnalisis = false;
        }
        private void ProcesarEstado11()
        {
            lexema = caracterActual;
            categoria = CategoriaGramatical.PARENTESIS_CIERRA;
            FormarComponenteLexicoLiteral();
            continuarAnalisis = false;
        }
        private void ProcesarEstado12()
        {
            categoria = CategoriaGramatical.FIN_DE_ARCHIVO;
            FormarComponenteLexicoLiteral();
            continuarAnalisis = false;

        }
        private void ProcesarEstado13()
        {
            CargarNuevaLinea();
            Resetear();
        }
        private void ProcesarEstado14()
        {
            DevolverPuntero();
            categoria = CategoriaGramatical.NUMERO_ENTERO;
            FormarComponenteLexicoLiteral();
            continuarAnalisis = false;

        }
        private void ProcesarEstado15()
        {
            DevolverPuntero();
            categoria = CategoriaGramatical.NUMERO_DECIMAL;
            FormarComponenteLexicoLiteral();
            continuarAnalisis = false;

        }

        private void ProcesarEstado16()
        {
            DevolverPuntero();
            categoria = CategoriaGramatical.IDENTIFICADOR;
            FormarComponenteLexicoSimbolo();
            continuarAnalisis = false;
        }
        private void ProcesarEstado17()
        {
            //ERROR NUMERO NO VÁLIDO
            DevolverPuntero();
            falla = "Número decimal no válido";
            causa = "Se recibió luego del separador decimal el símbolo " + caracterActual;
            solucion = "Asegurese que en la posición deseada se encuentre un dígito para formar un número decimal válido.";
            ReportarErrorLexicoRecuperable();
            caracterActual = "0";
            Concatenar();
            categoria = CategoriaGramatical.NUMERO_DECIMAL;
            FormarComponenteLexicoDummy();
            continuarAnalisis = false;
        }
        private void ProcesarEstado18()
        {
            //SIMBOLO NO VÁLIDO
            DevolverPuntero();
            falla = "Símbolo no válido";
            causa = "Se recibió el símbolo '" + caracterActual + "' no reconocido por el lenguaje.";
            solucion = "Asegúrese que en la posición esperada se encuentre un símbolo válido reconocido por el lenguaje";
            ReportarErrorLexicoStopper();
        }
        private void ProcesarEstado19()
        {
            categoria = CategoriaGramatical.IGUAL_QUE;
            FormarComponenteLexicoLiteral();
            continuarAnalisis = false;
        }
        private void ProcesarEstado33()
        {
            DevolverPuntero();
            categoria = CategoriaGramatical.DIVISION;
            FormarComponenteLexicoLiteral();
            continuarAnalisis = false;
        }
        private void ProcesarEstado34()
        {
            LeerSiguienteCaracter();
            if (UtilTexto.EsSignoAsterisco(caracterActual))
            {
                estadoActual = "q35";
            }

        }
        private void ProcesarEstado35()
        {
            LeerSiguienteCaracter();
            if (UtilTexto.EsSignoSlash(caracterActual))
            {
                estadoActual = "q0";
            }
            else if (!UtilTexto.EsSignoAsterisco(caracterActual))
            {
                estadoActual = "q34";
            }

        }
        private void ProcesarEstado36()
        {
            LeerSiguienteCaracter();
            if (UtilTexto.EsFL(caracterActual))
            {
                estadoActual = "q13";
            }
        }

        private void FormarComponenteLexicoSimbolo()
        {
            posicionInicial = puntero - lexema.Length;
            componente = ComponenteLexico.CrearSimbolo(numeroLineaActual, posicionInicial, lexema, categoria);
        }
        private void FormarComponenteLexicoLiteral()
        {
            posicionInicial = puntero - lexema.Length;
            componente = ComponenteLexico.CrearLiteral(numeroLineaActual, posicionInicial, lexema, categoria);
        }
        private void FormarComponenteLexicoDummy()
        {
            posicionInicial = puntero - lexema.Length;
            componente = ComponenteLexico.CrearDummy(numeroLineaActual, posicionInicial, lexema, categoria);
        }
        private void FormarComponenteLexicoPalabraReservada()
        {
            posicionInicial = puntero - lexema.Length;
            componente = ComponenteLexico.CrearPalabraReservada(numeroLineaActual, posicionInicial, lexema, categoria);
        }
        private void ReportarErrorLexicoRecuperable()
        {
            posicionInicial = puntero - lexema.Length;
            Error error = Error.CrearErrorLexicoRecuperable(numeroLineaActual, posicionInicial, lexema, falla, causa, solucion);
            ManejadorErrores.ObtenerManejadorDeErrores().ReportarError(error);
        }
        private void ReportarErrorLexicoStopper()
        {
            posicionInicial = puntero - lexema.Length;
            Error error = Error.CrearErrorLexicoStopper(numeroLineaActual, posicionInicial, lexema, falla, causa, solucion);
            ManejadorErrores.ObtenerManejadorDeErrores().ReportarError(error);
        }

        private void DevorarEspaciosEnBlanco()
        {
            LeerSiguienteCaracter();
            while ("".Equals(caracterActual.Trim()) || "\t".Equals(estadoActual))
            {
                LeerSiguienteCaracter();
            }
        }
    }
}
