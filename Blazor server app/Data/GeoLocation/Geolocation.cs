using Microsoft.JSInterop;

namespace Blazor_server_app.Data.GeoLocation
{
    public class Geolocation
    {
        private readonly IJSRuntime js;
        public Geolocation(IJSRuntime js)
        {
            this.js = js;
        }
        public async ValueTask<bool> HasGeolocationFeature() =>await js.InvokeAsync<bool>("blazorGeolocation.hasGeolocaitonFeature");
        private Action<Position> OnGetPosition;
        [JSInvokable]
        public void RaiseOnGetPosition(Position p) =>OnGetPosition?.Invoke(p);

        private Action<PositionError> OnGetPositionError;
        [JSInvokable]
        public void RaiseOnGetPositionError(PositionError err) =>OnGetPositionError?.Invoke(err);
        public async ValueTask GetCurrentPosition(Action<Position> onSuccess,Action<PositionError> onError, PositionOptions options = null)
        {
                    OnGetPosition = onSuccess;
                    OnGetPositionError = onError;
                    await js.InvokeVoidAsync
                   ("blazorGeolocation.getCurrentPosition",
                    DotNetObjectReference.Create(this), options);
        }
    }
}
