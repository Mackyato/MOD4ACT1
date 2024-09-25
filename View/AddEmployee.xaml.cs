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
	            //LocationLabel.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}";
	
	            // Get Geocoding - Get address from Longitude and Latitude
	            var placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);
	            var placemark = placemarks?.FirstOrDefault();
	
	            if (placemark != null)
	            {
	                // Set the Municipality and Province entry fields
	                Municipality.Text = placemark.Locality;
	                Province.Text = placemark.AdminArea;
	            }
	            else
	            {
	                AddressLabel.Text = "Unable to determine the address";
	            }
	        }
	        else
	        {
	            //LocationLabel.Text = "Unable to get location";
	        }
	    }
	    catch (Exception ex)
	    {
	        //LocationLabel.Text = $"ERROR: {ex.Message}";
	    }
     }
}
