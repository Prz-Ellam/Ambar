using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Cassandra;

namespace Ambar.ViewController
{
    public partial class Contracts : Form
    {
        ContractDAO dao = new ContractDAO();
        Dictionary<string, Guid> clients;
        int lbPrevIndex = -1;

        public Contracts()
        {
            InitializeComponent();
        }

        private void Contratos_Load(object sender, EventArgs e)
        {
            ClientDAO clientDAO = new ClientDAO();
            clients = clientDAO.ReadAllUsernames();
            foreach(var key in clients.Keys)
            {
                lbClients.Items.Add(key);
            }
        }

        private void lbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPrevIndex == lbClients.SelectedIndex)
            {
                txtClient.Clear();
                btnAccept.Enabled = false;
                lbPrevIndex = -1;
                dgvContracts.DataSource = null;
                lbClients.ClearSelected();
                return;
            }
            else
            {
                txtClient.Text = lbClients.SelectedItem.ToString();
                // Tambien anadir todos los contratos del cliente seleccionado en el data grid view
                dgvContracts.DataSource = dao.ReadClientContracts(lbClients.SelectedItem.ToString());
                btnAccept.Enabled = true;
                lbPrevIndex = lbClients.SelectedIndex;
            }
        }

        private void cbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] cities = null;

            switch (cbState.SelectedIndex)
            {
                case 0:
                {
                    cities = new string[] {"AGUASCALIENTES", "ASIENTOS", "CALVILLO", "COSÍO", "EL LLANO",
                    "JESÚS MARÍA", "PABELLÓN DE ARTEAGA", "RINCÓN DE ROMOS", "SAN FRANCISCO DE LOS ROMO",
                        "SAN JOSÉ DE GRACIA", "TEPEZALÁ" };
                    break;
                }
                case 1:
                {
                    cities = new string[] { "ENSENADA", "MEXICALI", "TECATE", "TIJUANA", "PLAYAS DE ROSARITO" };
                    break;
                }
                case 2:
                {
                    cities = new string[] { "COMONDÚ", "MULEGÉ", "LA PAZ", "LOS CABOS", "LORETO" };
                    break;
                }
                case 3:
                {
                    cities = new string[] {"CALKINÍ", "CAMPECHE", "CARMEN", "CHAMPOTÓN", "HECELCHAKÁN", "HOPELCHÉN",
                        "PALIZADA", "TENABO", "ESCÁRCEGA", "CALAKMUL", "CANDELARIA"};
                    break;
                }
                case 4:
                {
                    cities = new string[] { "ACACOYAGUA","ACALA","ACAPETAHUA","ALTAMIRANO","AMATÁN",
                    "AMATENANGO DE LA FRONTERA","AMATENANGO DEL VALLE","ANGEL ALBINO CORZO","ARRIAGA","BEJUCAL DE OCAMPO",
                        "BELLA VISTA","BERRIOZÁBAL","BOCHIL","EL BOSQUE","CACAHOATÁN","CATAZAJÁ","CINTALAPA",
                        "COAPILLA","COMITÁN DE DOMÍNGUEZ","LA CONCORDIA","COPAINALÁ","CHALCHIHUITÁN","CHAMULA","CHANAL",
                        "CHAPULTENANGO","CHENALHÓ","CHIAPA DE CORZO","CHIAPILLA","CHICOASÉN","CHICOMUSELO","CHILÓN",
                        "ESCUINTLA","FRANCISCO LEÓN","FRONTERA COMALAPA","FRONTERA HIDALGO","LA GRANDEZA","HUEHUETÁN",
                        "HUIXTÁN","HUITIUPÁN","HUIXTLA","LA INDEPENDENCIA","IXHUATÁN","IXTACOMITÁN","IXTAPA",
                        "IXTAPANGAJOYA","JIQUIPILAS","JITOTOL","JUÁREZ","LARRÁINZAR","LA LIBERTAD","MAPASTEPEC",
                        "LAS MARGARITAS","MAZAPA DE MADERO","MAZATÁN","METAPA","MITONTIC","MOTOZINTLA","NICOLÁS RUÍZ",
                        "OCOSINGO","OCOTEPEC","OCOZOCOAUTLA DE ESPINOSA","OSTUACÁN","OSUMACINTA","OXCHUC","PALENQUE",
                        "PANTELHÓ","PANTEPEC","PICHUCALCO","PIJIJIAPAN","EL PORVENIR",
                        "PUEBLO NUEVO SOLISTAHUACÁN","RAYÓN","REFORMA","LAS ROSAS","SABANILLA","SALTO DE AGUA",
                        "SAN CRISTÓBAL DE LAS CASAS","SAN FERNANDO","SILTEPEC","SIMOJOVEL","SITALÁ","SOCOLTENANGO",
                        "SOLOSUCHIAPA","SOYALÓ","SUCHIAPA","SUCHIATE","SUNUAPA","TAPACHULA","TAPALAPA","TAPILULA",
                        "TECPATÁN","TENEJAPA","TEOPISCA","TILA","TONALÁ","TOTOLAPA","LA TRINITARIA","TUMBALÁ",
                        "TUXTLA GUTIÉRREZ","TUXTLA CHICO","TUZANTÁN","TZIMOL","UNIÓN JUÁREZ","VENUSTIANO CARRANZA",
                        "VILLA COMALTITLÁN","VILLA CORZO","VILLAFLORES","YAJALÓN","SAN LUCAS","ZINACANTÁN",
                        "SAN JUAN CANCUC","ALDAMA","BENEMÉRITO DE LAS AMÉRICAS","MARAVILLA TENEJAPA","MARQUÉS DE COMILLAS",
                        "MONTECRISTO DE GUERRERO","SAN ANDRÉS DURAZNAL","SANTIAGO EL PINAR"};
                    break;
                }
                case 5:
                {
                    cities = new string[] { "AHUMADA", "ALDAMA", "ALLENDE", "AQUILES SERDÁN", "ASCENSIÓN", "BACHÍNIVA", 
                        "BALLEZA", "BATOPILAS", "BOCOYNA", "BUENAVENTURA", "CAMARGO", "CARICHÍ", "CASAS GRANDES", 
                        "CORONADO", "COYAME DEL SOTOL", "LA CRUZ", "CUAUHTÉMOC", "CUSIHUIRIACHI", "CHIHUAHUA", "CHÍNIPAS", 
                        "DELICIAS", "DR. BELISARIO DOMÍNGUEZ", "GALEANA", "SANTA ISABEL", "GÓMEZ FARÍAS", "GRAN MORELOS", 
                        "GUACHOCHI", "GUADALUPE", "GUADALUPE Y CALVO", "GUAZAPARES", "GUERRERO", "HIDALGO DEL PARRAL", 
                        "HUEJOTITÁN", "IGNACIO ZARAGOZA", "JANOS", "JIMÉNEZ", "JUÁREZ", "JULIMES", "LÓPEZ", "MADERA", 
                        "MAGUARICHI", "MANUEL BENAVIDES", "MATACHÍ", "MATAMOROS", "MEOQUI", "MORELOS", "MORIS", "NAMIQUIPA",
                        "NONOAVA", "NUEVO CASAS GRANDES", "OCAMPO", "OJINAGA", "PRAXEDIS G. GUERRERO", "RIVA PALACIO", 
                        "ROSALES", "ROSARIO", "SAN FRANCISCO DE BORJA", "SAN FRANCISCO DE CONCHOS", "SAN FRANCISCO DEL ORO",
                        "SANTA BÁRBARA", "SATEVÓ", "SAUCILLO", "TEMÓSACHIC", "EL TULE", "URIQUE", "URUACHI", "VALLE DE ZARAGOZA"};
                    break;
                }
                case 6: // Ciudad de Mexico
                {
                    cities = new string[] {"AZCAPOTZALCO", "COYOACÁN", "CUAJIMALPA DE MORELOS", "GUSTAVO A. MADERO",
                        "IZTACALCO", "IZTAPALAPA", "LA MAGDALENA CONTRERAS", "MILPA ALTA", "ÁLVARO OBREGÓN", "TLÁHUAC",
                        "TLALPAN", "XOCHIMILCO", "BENITO JUÁREZ", "CUAUHTÉMOC", "MIGUEL HIDALGO", "VENUSTIANO CARRANZA" };
                    break;
                }
                case 7: // Coahuila
                {
                    cities = new string[] { "ABASOLO", "ACUÑA", "ALLENDE", "ARTEAGA", "CANDELA", "CASTAÑOS",
                        "CUATRO CIÉNEGAS", "ESCOBEDO", "FRANCISCO I. MADERO", "FRONTERA", "GENERAL CEPEDA", "GUERRERO",
                        "HIDALGO", "JIMÉNEZ", "JUÁREZ", "LAMADRID", "MATAMOROS", "MONCLOVA", "MORELOS", "MÚZQUIZ",
                        "NADADORES", "NAVA", "OCAMPO", "PARRAS", "PIEDRAS NEGRAS", "PROGRESO", "RAMOS ARIZPE", "SABINAS",
                        "SACRAMENTO", "SALTILLO", "SAN BUENAVENTURA", "SAN JUAN DE SABINAS", "SAN PEDRO", "SIERRA MOJADA",
                        "TORREÓN", "VIESCA", "VILLA UNIÓN", "ZARAGOZA" };
                    break;
                }
                case 8: // Columna
                {
                    cities = new string[] { "ARMERÍA", "COLIMA", "COMALA", "COQUIMATLÁN", "CUAUHTÉMOC", "IXTLAHUACÁN",
                       "MANZANILLO", "MINATITLÁN", "TECOMÁN", "VILLA DE ÁLVAREZ", "DURANGO", "DURANGO", "CANATLÁN",
                        "CANELAS", "CONETO DE COMONFORT", "CUENCAMÉ", "GENERAL SIMÓN BOLÍVAR", "GÓMEZ PALACIO",
                        "GUADALUPE VICTORIA", "GUANACEVÍ", "HIDALGO", "INDÉ", "LERDO", "MAPIMÍ", "MEZQUITAL", "NAZAS",
                        "NOMBRE DE DIOS", "NUEVO IDEAL", "OCAMPO", "EL ORO", "OTÁEZ", "PÁNUCO DE CORONADO", "PEÑÓN BLANCO",
                        "POANAS", "PUEBLO NUEVO", "RODEO", "SAN BERNARDO", "SAN DIMAS", "SAN JUAN DE GUADALUPE",
                        "SAN JUAN DEL RÍO", "SAN LUIS DEL CORDERO", "SAN PEDRO DEL GALLO", "SANTA CLARA", 
                        "SANTIAGO PAPASQUIARO", "SÚCHIL", "TAMAZULA", "TEPEHUANES", "TLAHUALILO", "TOPIA", 
                        "VICENTE GUERRERO" };
                    break;
                }
                case 9: // Guanajuato
                {
                    cities = new string[] { "ABASOLO", "ACÁMBARO", "SAN MIGUEL DE ALLENDE", "APASEO EL ALTO",
                        "APASEO EL GRANDE", "ATARJEA", "CELAYA", "COMONFORT", "CORONEO", "CORTAZAR", "CUERÁMARO",
                        "DOCTOR MORA", "DOLORES HIDALGO CUNA DE LA INDEPENDENCIA NACIONAL", "GUANAJUATO", "HUANÍMARO",
                        "IRAPUATO", "JARAL DEL PROGRESO", "JERÉCUARO", "LEÓN", "MANUEL DOBLADO", "MOROLEÓN", "OCAMPO",
                        "PÉNJAMO", "PUEBLO NUEVO", "PURÍSIMA DEL RINCÓN", "ROMITA", "SALAMANCA", "SALVATIERRA",
                        "SAN DIEGO DE LA UNIÓN", "SAN FELIPE", "SAN FRANCISCO DEL RINCÓN", "SAN JOSÉ ITURBIDE",
                        "SAN LUIS DE LA PAZ", "SANTA CATARINA", "SANTA CRUZ DE JUVENTINO ROSAS", "SANTIAGO MARAVATÍO",
                        "SILAO DE LA VICTORIA", "TARANDACUAO", "TARIMORO", "TIERRA BLANCA", "URIANGATO",
                        "VALLE DE SANTIAGO", "VICTORIA", "VILLAGRÁN", "XICHÚ", "YURIRIA" };
                    break;
                }
                case 10: // Guerrero
                {
                    cities = new string[] { "ACAPULCO DE JUÁREZ", "ACATEPEC", "AHUACUOTZINGO", "AJUCHITLÁN DEL PROGRESO", 
                        "ALCOZAUCA DE GUERRERO", "ALPOYECA", "APAXTLA", "ARCELIA", "ATENANGO DEL RÍO", "ATLAMAJALCINGO DEL MONTE", 
                        "ATLIXTAC", "ATOYAC DE ÁLVAREZ", "AYUTLA DE LOS LIBRES", "AZOYÚ", "BENITO JUÁREZ", "BUENAVISTA DE CUÉLLAR", 
                        "COAHUAYUTLA DE JOSÉ MARÍA IZAZAGA", "COCHOAPA EL GRANDE", "COCULA", "COPALA", "COPALILLO", "COPANATOYAC", 
                        "COYUCA DE BENÍTEZ", "COYUCA DE CATALÁN", "CUAJINICUILAPA", "CUALÁC", "CUAUTEPEC", "CUETZALA DEL PROGRESO", 
                        "CUTZAMALA DE PINZÓN", "CHILAPA DE ÁLVAREZ", "CHILPANCINGO DE LOS BRAVO", "EDUARDO NERI", "FLORENCIO VILLARREAL", 
                        "GENERAL CANUTO A. NERI", "GENERAL HELIODORO CASTILLO", "HUAMUXTITLÁN", "HUITZUCO DE LOS FIGUEROA", 
                        "IGUALA DE LA INDEPENDENCIA", "IGUALAPA", "ILIATENCO", "IXCATEOPAN DE CUAUHTÉMOC", "JOSÉ JOAQUÍN DE HERRERA", 
                        "JUCHITÁN", "JUAN R. ESCUDERO", "LEONARDO BRAVO", "MALINALTEPEC", "MARQUELIA", "MÁRTIR DE CUILAPAN", 
                        "METLATÓNOC", "MOCHITLÁN", "OLINALÁ", "OMETEPEC", "PEDRO ASCENCIO ALQUISIRAS", "PETATLÁN", "PILCAYA", 
                        "PUNGARABATO", "QUECHULTENANGO", "SAN LUIS ACATLÁN", "SAN MARCOS", "SAN MIGUEL TOTOLAPAN", "TAXCO DE ALARCÓN", 
                        "TECOANAPA", "TÉCPAN DE GALEANA", "TELOLOAPAN", "TEPECOACUILCO DE TRUJANO", "TETIPAC", "TIXTLA DE GUERRERO", 
                        "TLACOACHISTLAHUACA", "TLACOAPA", "TLALCHAPA", "TLALIXTAQUILLA DE MALDONADO", "TLAPA DE COMONFORT", "TLAPEHUALA", 
                        "LA UNIÓN DE ISIDORO MONTES DE OCA", "XALPATLÁHUAC", "XOCHIHUEHUETLÁN", "XOCHISTLAHUACA", "ZAPOTITLÁN TABLAS", 
                        "ZIHUATANEJO DE AZUETA", "ZIRÁNDARO", "ZITLALA" };
                    break;
                }
            }

            cbCity.Items.Clear();
            foreach (var city in cities)
            {
                cbCity.Items.Add(city);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Agregar un contrato
            if (txtMeterSerialNumber.Text == string.Empty || txtServiceNumber.Text == string.Empty || 
                cbService.SelectedIndex == -1 || cbState.SelectedIndex == -1 || cbCity.SelectedIndex == -1 ||
                txtSuburb.Text == string.Empty || txtStreet.Text == string.Empty || txtNumber.Text == string.Empty || 
                txtPostalCode.Text == string.Empty)
            {

            }

            ContractDTO contract = new ContractDTO();
            DateTime today = DateTime.Now;
            contract.Client_ID = clients[txtClient.Text];
            contract.Meter_Serial_Number = txtMeterSerialNumber.Text;
            contract.Service_Number = Convert.ToInt32(txtServiceNumber.Text);
            contract.State = cbState.Text;
            contract.City = cbCity.Text;
            contract.Suburb = txtSuburb.Text;
            contract.Street = txtStreet.Text;
            contract.Number = txtNumber.Text;
            contract.Postal_Code = txtPostalCode.Text;
            contract.Service = cbService.Text;
            contract.Start_Period_Date = new LocalDate(today.Year, today.Month, today.Day);

            dao.Create(contract);


        }
    }
}
