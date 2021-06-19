﻿using Servicios.Business;
using Servicios.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DSI2021.Frontend {
    public partial class PantallaRegistroVenta : Form {

        Hora duracionVisita;

        public PantallaRegistroVenta() {
            InitializeComponent();
        }

        public void Abrir(Form formulario) {
            formulario.ShowDialog();
            duracionVisita = GestorRegistroVenta.CalcularDuracionVisita();
            lblDuracionVisita = duracionVisita.ToString();
            Hide();
        }

        private void btnGenerar(object sender, EventArgs e) {
            int cantidadEntradas;
            int montoPorEntrada;
            int montoTotal;

            cantidadEntradas = GetCantidadEntradas();

            Tarifa tarifaSeleccionada = GetTarifaSeleccionada();
            if (tarifaSeleccionada == null) {
                MessageBox.Show("Seleccione una tarifa.");
                return;
            }
            montoPorEntrada = tarifaSeleccionada.GetMonto();
            montoTotal = montoPorEntrada * cantidadEntradas;

            Abrir(new frmVentanaConfirmacion(cantidadEntradas, montoPorEntrada, montoTotal));
        }

        private int GetCantidadEntradas() {
            int cantEntradas = 0;
            if (int.TryParse(txtCantEntradas.Text, out cantEntradas))
                return cantEntradas;

            return 0;
        }

        private Tarifa GetTarifaSeleccionada() {
            return tablaTarifas.SelectedRows[0]?.Tag as Tarifa;
        }

        private void PantallaRegistroVenta_Load(object sender, EventArgs e) {
            List<Tarifa> tarifasValidas = GestorRegistroVenta.BuscarTarifasVigentes();
            MostrarTarifas(tarifasValidas);
        }

        public void MostrarTarifas(List<Tarifa> tarifas) {
            foreach (Tarifa tarifa in tarifas) {
                var monto = tarifa.GetMonto();
                var montoAdicional = tarifa.GetMontoAdicional();
                var tipoEntrada = tarifa.GetTipoEntrada().GetNombre();
                var tipoVisita = tarifa.GetTipoVisita().GetNombre();

                int newRowIx = tablaTarifas.Rows.Add(monto, montoAdicional, tipoEntrada, tipoVisita);
                tablaTarifas.Rows[newRowIx].Tag = tarifa;
            }
        }
    }
}
