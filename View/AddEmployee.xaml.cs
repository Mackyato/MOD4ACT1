namespace Module0Exercise0.View;

public partial class AddEmployee : ContentPage
{
	public AddEmployee()
	{
		InitializeComponent();
	}

    //CAMERA
    //<<-- EVENT CAPTURE IMAGE
    private async void OnCapturePhotoClicked(object sender, EventArgs e)
    {
        try
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                //capture photo using Media Picker
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    await LoadPhotoAsync(photo);
                }

            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occured: {ex.Message}", "OK");
        }
    }
    //END HERE -->>


    //LOAD PHOTO AND DISPLAY IT IN THE IMAGE CONTROL
    private async Task LoadPhotoAsync(FileResult photo)
    {
        if (photo == null)
            return;

        Stream stream = await photo.OpenReadAsync();

        CaptureImage.Source = ImageSource.FromStream(() => stream);
    }
    private async void OnGetLocationClicked(object sender, EventArgs e)
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.High
                });
            }

            if (location != null)
            {
                coordinatesLabel.Text = $"Latitude: {location.Latitude}, Longtitude: {location.Longitude}";

                var placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);

                var placemark = placemarks?.FirstOrDefault();

                if (placemark != null)
                {
                    Municipality.Text = $"Municipality: {placemark.Locality}," +
                        $"{placemark.AdminArea}";
                }
                else
                {
                    Municipality.Text = "Unable to determie the address";
                }
                //GEOCODING ENDS HERE

            }
            else
            {
                coordinatesLabel.Text = "Unable to get Location";
            }
        }
        catch (Exception ex)
        {
            coordinatesLabel.Text = $"ERROR: {ex.Message}";
        }
    }
}