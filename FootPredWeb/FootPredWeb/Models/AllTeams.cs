using System;

namespace FootPredWeb.Models
{
    public class TeamList
    {
        static string[] m_AllTeams = null;

        public static string[] AllTeams
        {
            get
            {
                if (m_AllTeams == null)
                    m_AllTeams = AllTeamsString.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                return m_AllTeams;
            }
        }

        static string AllTeamsString = @"Afghanistan
Albania
Algeria
American Samoa
Andorra
Angola
Anguilla
Antigua and Barbuda
Argentina
Armenia
Aruba
Australia
Austria
Azerbaijan
Bahamas
Bahrain
Bangladesh
Barbados
Belarus
Belgium
Belize
Benin
Bermuda
Bhutan
Bolivia
Bosnia & Herzegovina
Botswana
Brazil
British Virgin Islands
Brunei Darussalam
Bulgaria
Burkina Faso
Burundi
Cambodia
Cameroon
Canada
Cape Verde Islands
Cayman Islands
Central African Republic
Chad
Chile
China PR
Chinese Taipei
Colombia
Comoros
Congo
Congo DR
Cook Islands
Costa Rica
Côte d'Ivoire
Croatia
Cuba
Curaçao
Cyprus
Czech Republic
Denmark
Djibouti
Dominica
Dominican Republic
Ecuador
Egypt
El Salvador
England
Equatorial Guinea
Eritrea
Estonia
Ethiopia
Faroe Islands
Fiji
Finland
France
FYR Macedonia
Gabon
Gambia
Georgia
Germany
Ghana
Greece
Grenada
Guam
Guatemala
Guinea
Guinea-Bissau
Guyana
Haiti
Honduras
Hong Kong
Hungary
Iceland
India
Indonesia
Iran
Iraq
Israel
Italy
Jamaica
Japan
Jordan
Kazakhstan
Kenya
Korea DPR
Korea Republic
Kuwait
Kyrgyzstan
Laos
Latvia
Lebanon
Lesotho
Liberia
Libya
Liechtenstein
Lithuania
Luxembourg
Macau
Madagascar
Malawi
Malaysia
Maldives
Mali
Malta
Mauritania
Mauritius
Mexico
Moldova
Mongolia
Montenegro
Montserrat
Morocco
Mozambique
Myanmar
Namibia
Nepal
Netherlands
New Caledonia
New Zealand
Nicaragua
Niger
Nigeria
North. Ireland
Norway
Oman
Pakistan
Palestine
Panama
Papua New Guinea
Paraguay
Peru
Philippines
Poland
Portugal
Puerto Rico
Qatar
Rep. of Ireland
Romania
Russia
Rwanda
Samoa
San Marino
São Tomé e Príncipe
Saudi Arabia
Scotland
Senegal
Serbia
Seychelles
Sierra Leone
Singapore
Slovakia
Slovenia
Solomon Islands
Somalia
South Africa
South Sudan
Spain
Sri Lanka
St. Kitts and Nevis
St. Lucia
St. Vincent and the Grenadines
Sudan
Suriname
Swaziland
Sweden
Switzerland
Syria
Tahiti
Tajikistan
Tanzania
Thailand
Timor-Leste
Togo
Tonga
Trinidad and Tobago
Tunisia
Turkey
Turkmenistan
Turks and Caicos Islands
Uganda
Ukraine
United Arab Emirates
United States
Uruguay
US Virgin Islands
Uzbekistan
Vanuatu
Venezuela
Vietnam
Wales
Yemen
Zambia
Zimbabwe";

    }

}