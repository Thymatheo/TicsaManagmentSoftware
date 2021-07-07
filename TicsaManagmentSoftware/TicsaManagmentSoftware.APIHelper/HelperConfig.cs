using System;

namespace TicsaManagmentSoftware.APIHelper {
    public class HelperConfig {
        private string _UrlApi;
        private string _AuthKey;

        /// <summary>
        /// The base URI
        /// </summary>
        public string UrlApi {
            get => _UrlApi ?? throw new NullReferenceException("Impossible de trouvé la clé \"UrlApiRoutage\" dans la configuration");
            set {
                if (_UrlApi != value) {
                    _UrlApi = value;
                }
            }
        }

        /// <summary>
        /// The authorization key
        /// </summary>
        public string AuthKey {
            get => _AuthKey ?? throw new NullReferenceException("Impossible de trouvé la clé \"AuthorizeKey\" dans la configuration");
            set {
                if (_AuthKey != value) {
                    _AuthKey = value;
                }
            }
        }
    }
}
