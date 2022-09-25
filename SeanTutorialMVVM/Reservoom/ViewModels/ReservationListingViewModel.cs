using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        private readonly HotelStore _hotelStore;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            { 
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);


        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set 
            { 
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }


        public ICommand LoadReservationsCommand { get; }
        public ICommand MakeReservationCommand { get; }


        public ReservationListingViewModel(HotelStore hotelStore, NavigationService makeReservationNavigationService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
            _hotelStore = hotelStore;

            LoadReservationsCommand = new LoadReservationsCommand(this, hotelStore);
            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);

            _hotelStore.ReservationMade += OnReservationMade;
        }

        public override void Dispose()
        {
            _hotelStore.ReservationMade -= OnReservationMade;
            base.Dispose();
        }

        private void OnReservationMade(Reservation reservation)
        {
            var reservationViewModel = new ReservationViewModel(reservation);
            _reservations.Add(reservationViewModel);
        }

        public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore, NavigationService makeReservationNavigationServic)
        {
            var viewModel = new ReservationListingViewModel(hotelStore, makeReservationNavigationServic);

            viewModel.LoadReservationsCommand.Execute(null);

            return viewModel;
        }

        public void UpdateReservations(IEnumerable<Reservation> reservations)
        {
            _reservations.Clear();

            foreach(Reservation reservation in reservations)
            {
                var reservationViewModel = new ReservationViewModel(reservation);

                _reservations.Add(reservationViewModel);
            }
        }
    }
}
