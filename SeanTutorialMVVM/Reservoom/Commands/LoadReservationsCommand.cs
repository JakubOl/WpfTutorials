﻿using Reservoom.Models;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom.Commands
{
    public class LoadReservationsCommand : AsyncCommandBase
    {
        private readonly ReservationListingViewModel _viewModel;
        private readonly Hotel _hotel;

        public LoadReservationsCommand(ReservationListingViewModel viewModel, Hotel hotel)
        {
            _viewModel = viewModel;
            _hotel = hotel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                var reservations = await _hotel.GetAllReservations();

                _viewModel.UpdateReservations(reservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to make reservation", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}