﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Cassandra;
using Ambar.Common;

namespace Ambar.ViewController
{
    public partial class Contracts : Form
    {
        ContractDAO dao = new ContractDAO();
        int lbPrevIndex = -1;
        int dtgPrevIndex = -1;

        public Contracts()
        {
            InitializeComponent();
        }

        private void Contratos_Load(object sender, EventArgs e)
        {
            ClientDAO clientDAO = new ClientDAO();
            List<ClientDTO> clients = clientDAO.ReadAll();
            List<ClientDTG> dtgClients = new List<ClientDTG>();
            foreach (var client in clients)
            {
                dtgClients.Add(new ClientDTG(client));
            }
            this.dtgClients.DataSource = dtgClients;
            this.dtgClients.Columns["Emails"].Visible = false;
        }

        private void lbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lbPrevIndex == lbClients.SelectedIndex)
            //{
            //    txtClient.Clear();
            //    btnAccept.Enabled = false;
            //    lbPrevIndex = -1;
            //    dtgContracts.Rows.Clear();
            //    lbClients.ClearSelected();
            //    return;
            //}
            //else
            //{
            //    txtClient.Text = lbClients.SelectedItem.ToString();
            //    FillDataGridView();
            //    btnAccept.Enabled = true;
            //    lbPrevIndex = lbClients.SelectedIndex;
            //}
        }

        private void cbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] cities = null;

            switch (cbState.SelectedIndex)
            {
                case -1:
                {
                    return;
                }
                case 0: // Aguascalientes
                {
                    cities = new string[] {"AGUASCALIENTES", "ASIENTOS", "CALVILLO", "COSÍO", "EL LLANO",
                    "JESÚS MARÍA", "PABELLÓN DE ARTEAGA", "RINCÓN DE ROMOS", "SAN FRANCISCO DE LOS ROMO",
                        "SAN JOSÉ DE GRACIA", "TEPEZALÁ" };
                    break;
                }
                case 1: // Baja California 
                {
                    cities = new string[] { "ENSENADA", "MEXICALI", "TECATE", "TIJUANA", "PLAYAS DE ROSARITO" };
                    break;
                }
                case 2: // Baja California Sur
                {
                    cities = new string[] { "COMONDÚ", "MULEGÉ", "LA PAZ", "LOS CABOS", "LORETO" };
                    break;
                }
                case 3: // Campeche
                {
                    cities = new string[] {"CALKINÍ", "CAMPECHE", "CARMEN", "CHAMPOTÓN", "HECELCHAKÁN", "HOPELCHÉN",
                        "PALIZADA", "TENABO", "ESCÁRCEGA", "CALAKMUL", "CANDELARIA"};
                    break;
                }
                case 4: // Chiapas
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
                case 5: // Chihuahua
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
                case 8: // Colima
                {
                    cities = new string[] { "ARMERÍA", "COLIMA", "COMALA", "COQUIMATLÁN", "CUAUHTÉMOC", "IXTLAHUACÁN",
                       "MANZANILLO", "MINATITLÁN", "TECOMÁN", "VILLA DE ÁLVAREZ" };
                    break;
                }
                case 9: // Durango
                {
                    cities = new string[] { "CANATLÁN", "CANELAS", "CONETO DE COMONFORT", "CUENCAMÉ", "DURANGO", 
                        "GENERAL SIMÓN BOLÍVAR", "GÓMEZ PALACIO", "GUADALUPE VICTORIA", "GUANACEVÍ", "HIDALGO", "INDÉ", "LERDO", 
                        "MAPIMÍ", "MEZQUITAL", "NAZAS", "NOMBRE DE DIOS", "NUEVO IDEAL", "OCAMPO", "EL ORO", "OTÁEZ", 
                        "PÁNUCO DE CORONADO", "PEÑÓN BLANCO", "POANAS", "PUEBLO NUEVO", "RODEO", "SAN BERNARDO", "SAN DIMAS", 
                        "SAN JUAN DE GUADALUPE", "SAN JUAN DEL RÍO", "SAN LUIS DEL CORDERO", "SAN PEDRO DEL GALLO", "SANTA CLARA",
                        "SANTIAGO PAPASQUIARO", "SÚCHIL", "TAMAZULA", "TEPEHUANES", "TLAHUALILO", "TOPIA",
                        "VICENTE GUERRERO" };
                    break;
                }
                case 10: // Guanajuato
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
                case 11: // Guerrero
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
                case 12: // Hidalgo
                {
                    cities = new string[] { "ACATLÁN", "ACAXOCHITLÁN", "ACTOPAN", "AGUA BLANCA DE ITURBIDE", "AJACUBA", "ALFAJAYUCAN", 
                        "ALMOLOYA", "APAN", "EL ARENAL", "ATITALAQUIA", "ATLAPEXCO", "ATOTONILCO EL GRANDE", "ATOTONILCO DE TULA", 
                        "CALNALI", "CARDONAL", "CUAUTEPEC DE HINOJOSA", "CHAPANTONGO", "CHAPULHUACÁN", "CHILCUAUTLA", "ELOXOCHITLÁN", 
                        "EMILIANO ZAPATA", "EPAZOYUCAN", "FRANCISCO I. MADERO", "HUASCA DE OCAMPO", "HUAUTLA", "HUAZALINGO", 
                        "HUEHUETLA", "HUEJUTLA DE REYES", "HUICHAPAN", "IXMIQUILPAN", "JACALA DE LEDEZMA", "JALTOCÁN", "JUÁREZ HIDALGO", 
                        "LOLOTLA", "METEPEC", "SAN AGUSTÍN METZQUITITLÁN", "METZTITLÁN", "MINERAL DEL CHICO", "MINERAL DEL MONTE", 
                        "LA MISIÓN", "MIXQUIAHUALA DE JUÁREZ", "MOLANGO DE ESCAMILLA", "NICOLÁS FLORES", "NOPALA DE VILLAGRÁN",
                        "OMITLÁN DE JUÁREZ", "SAN FELIPE ORIZATLÁN", "PACULA", "PACHUCA DE SOTO", "PISAFLORES", "PROGRESO DE OBREGÓN", 
                        "MINERAL DE LA REFORMA", "SAN AGUSTÍN TLAXIACA", "SAN BARTOLO TUTOTEPEC", "SAN SALVADOR", "SANTIAGO DE ANAYA", 
                        "SANTIAGO TULANTEPEC DE LUGO GUERRERO", "SINGUILUCAN", "TASQUILLO", "TECOZAUTLA", "TENANGO DE DORIA", 
                        "TEPEAPULCO", "TEPEHUACÁN DE GUERRERO", "TEPEJI DEL RÍO DE OCAMPO", "TEPETITLÁN", "TETEPANGO", 
                        "VILLA DE TEZONTEPEC", "TEZONTEPEC DE ALDAMA", "TIANGUISTENGO", "TIZAYUCA", "TLAHUELILPAN", "TLAHUILTEPA", 
                        "TLANALAPA", "TLANCHINOL", "TLAXCOAPAN", "TOLCAYUCA", "TULA DE ALLENDE", "TULANCINGO DE BRAVO", "XOCHIATIPAN", 
                        "XOCHICOATLÁN", "YAHUALICA", "ZACUALTIPÁN DE ÁNGELES", "ZAPOTLÁN DE JUÁREZ", "ZEMPOALA", "ZIMAPÁN"};
                    break;
                }
                case 13: // Jalisco
                {
                    cities = new string[] { "ACATIC", "ACATLÁN DE JUÁREZ", "AHUALULCO DE MERCADO", "AMACUECA", "AMATITÁN", 
                        "AMECA", "ARANDAS", "EL ARENAL", "ATEMAJAC DE BRIZUELA", "ATENGO", "ATENGUILLO", 
                        "ATOTONILCO EL ALTO", "ATOYAC", "AUTLÁN DE NAVARRO", "AYOTLÁN", "AYUTLA", "LA BARCA", "BOLAÑOS", 
                        "CABO CORRIENTES", "CAÑADAS DE OBREGÓN", "CASIMIRO CASTILLO", "CIHUATLÁN", "COCULA", "COLOTLÁN", 
                        "CONCEPCIÓN DE BUENOS AIRES", "CUAUTITLÁN DE GARCÍA BARRAGÁN", "CUAUTLA", "CUQUÍO", "CHAPALA", 
                        "CHIMALTITÁN", "CHIQUILISTLÁN", "DEGOLLADO", "EJUTLA", "ENCARNACIÓN DE DÍAZ", "ETZATLÁN", 
                        "EL GRULLO", "GUACHINANGO", "GUADALAJARA", "HOSTOTIPAQUILLO", "HUEJÚCAR", "HUEJUQUILLA EL ALTO", 
                        "LA HUERTA", "IXTLAHUACÁN DE LOS MEMBRILLOS", "IXTLAHUACÁN DEL RÍO", "JALOSTOTITLÁN", "JAMAY", 
                        "JESÚS MARÍA", "JILOTLÁN DE LOS DOLORES", "JOCOTEPEC", "JUANACATLÁN", "JUCHITLÁN", 
                        "LAGOS DE MORENO", "EL LIMÓN", "MAGDALENA", "SANTA MARÍA DEL ORO", "LA MANZANILLA DE LA PAZ", 
                        "MASCOTA", "MAZAMITLA", "MEXTICACÁN", "MEZQUITIC", "MIXTLÁN", "OCOTLÁN", "OJUELOS DE JALISCO", 
                        "PIHUAMO", "PONCITLÁN", "PUERTO VALLARTA", "VILLA PURIFICACIÓN", "QUITUPAN", "EL SALTO", 
                        "SAN CRISTÓBAL DE LA BARRANCA", "SAN DIEGO DE ALEJANDRÍA", "SAN JUAN DE LOS LAGOS", 
                        "SAN JUANITO DE ESCOBEDO", "SAN JULIÁN", "SAN MARCOS", "SAN MARTÍN DE BOLAÑOS", 
                        "SAN MARTÍN HIDALGO", "SAN MIGUEL EL ALTO", "GÓMEZ FARÍAS", "SAN SEBASTIÁN DEL OESTE", 
                        "SANTA MARÍA DE LOS ÁNGELES", "SAYULA", "TALA", "TALPA DE ALLENDE", "TAMAZULA DE GORDIANO", 
                        "TAPALPA", "TECALITLÁN", "TECOLOTLÁN", "TECHALUTA DE MONTENEGRO", "TENAMAXTLÁN", "TEOCALTICHE", 
                        "TEOCUITATLÁN DE CORONA", "TEPATITLÁN DE MORELOS", "TEQUILA", "TEUCHITLÁN", "TIZAPÁN EL ALTO", 
                        "TLAJOMULCO DE ZÚÑIGA", "SAN GABRIEL", "SAN IGNACIO CERRO GORDO", "SAN PEDRO TLAQUEPAQUE", 
                        "TOLIMÁN", "TOMATLÁN", "TONALÁ", "TONAYA", "TONILA", "TOTATICHE", "TOTOTLÁN", "TUXCACUESCO", 
                        "TUXCUECA", "TUXPAN", "UNIÓN DE SAN ANTONIO", "UNIÓN DE TULA", "VALLE DE GUADALUPE", 
                        "VALLE DE JUÁREZ", "VILLA CORONA", "VILLA GUERRERO", "VILLA HIDALGO", "YAHUALICA DE GONZÁLEZ GALLO", 
                        "ZACOALCO DE TORRES", "ZAPOPAN", "ZAPOTILTIC", "ZAPOTITLÁN DE VADILLO", "ZAPOTLÁN DEL REY", 
                        "ZAPOTLÁN EL GRANDE", "ZAPOTLANEJO"};
                    break;
                }
                case 14: // Mexico
                {
                    cities = new string[] { "ACAMBAY DE RUÍZ CASTAÑEDA", "ACOLMAN", "ACULCO", "ALMOLOYA DE ALQUISIRAS", 
                        "ALMOLOYA DE JUÁREZ", "ALMOLOYA DEL RÍO", "AMANALCO", "AMATEPEC", "AMECAMECA", "APAXCO", "ATENCO", 
                        "ATIZAPÁN", "ATIZAPÁN DE ZARAGOZA", "ATLACOMULCO", "ATLAUTLA", "AXAPUSCO", "AYAPANGO", "CALIMAYA", 
                        "CAPULHUAC", "COACALCO DE BERRIOZÁBAL", "COATEPEC HARINAS", "COCOTITLÁN", "COYOTEPEC", "CUAUTITLÁN", 
                        "CHALCO", "CHAPA DE MOTA", "CHAPULTEPEC", "CHIAUTLA", "CHICOLOAPAN", "CHICONCUAC", "CHIMALHUACÁN", 
                        "CUAUTITLÁN IZCALLI", "DONATO GUERRA", "ECATEPEC DE MORELOS", "ECATZINGO", "HUEHUETOCA", 
                        "HUEYPOXTLA", "HUIXQUILUCAN", "ISIDRO FABELA", "IXTAPALUCA", "IXTAPAN DE LA SAL", "IXTAPAN DEL ORO", 
                        "IXTLAHUACA", "XALATLACO", "JALTENCO", "JILOTEPEC", "JILOTZINGO", "JIQUIPILCO", "JOCOTITLÁN", 
                        "JOQUICINGO", "JUCHITEPEC", "LERMA", "LUVIANOS", "MALINALCO", "MELCHOR OCAMPO", "METEPEC", 
                        "MEXICALTZINGO", "MORELOS", "NAUCALPAN DE JUÁREZ", "NEZAHUALCÓYOTL", "NEXTLALPAN", "NICOLÁS ROMERO",
                        "NOPALTEPEC", "OCOYOACAC", "OCUILAN", "EL ORO", "OTUMBA", "OTZOLOAPAN", "OTZOLOTEPEC", "OZUMBA", 
                        "PAPALOTLA", "LA PAZ", "POLOTITLÁN", "RAYÓN", "SAN ANTONIO LA ISLA", "SAN FELIPE DEL PROGRESO", 
                        "SAN JOSÉ DEL RINCÓN", "SAN MARTÍN DE LAS PIRÁMIDES", "SAN MATEO ATENCO", "SAN SIMÓN DE GUERRERO", 
                        "SANTO TOMÁS", "SOYANIQUILPAN DE JUÁREZ", "SULTEPEC", "TECÁMAC", "TEJUPILCO", "TEMAMATLA", 
                        "TEMASCALAPA", "TEMASCALCINGO", "TEMASCALTEPEC", "TEMOAYA", "TENANCINGO", "TENANGO DEL AIRE", 
                        "TENANGO DEL VALLE", "TEOLOYUCAN", "TEOTIHUACÁN", "TEPETLAOXTOC", "TEPETLIXPA", "TEPOTZOTLÁN", 
                        "TEQUIXQUIAC", "TEXCALTITLÁN", "TEXCALYACAC", "TEXCOCO", "TEZOYUCA", "TIANGUISTENCO", "TIMILPAN", 
                        "TLALMANALCO", "TLALNEPANTLA DE BAZ", "TLATLAYA", "TOLUCA", "TONANITLA", "TONATICO", "TULTEPEC", 
                        "TULTITLÁN", "VALLE DE BRAVO", "VALLE DE CHALCO SOLIDARIDAD", "VILLA DE ALLENDE", "VILLA DEL CARBÓN", 
                        "VILLA GUERRERO", "VILLA VICTORIA", "XONACATLÁN", "ZACAZONAPAN", "ZACUALPAN", "ZINACANTEPEC", 
                        "ZUMPAHUACÁN", "ZUMPANGO" };
                    break;
                }
                case 15: // Michoacan
                {
                    cities = new string[] { "ACUITZIO", "AGUILILLA", "ÁLVARO OBREGÓN", "ANGAMACUTIRO", "ANGANGUEO", 
                        "APATZINGÁN", "APORO", "AQUILA", "ARIO", "ARTEAGA", "BRISEÑAS", "BUENAVISTA", "CARÁCUARO", 
                        "COAHUAYANA", "COALCOMÁN DE VÁZQUEZ PALLARES", "COENEO", "COJUMATLÁN DE RÉGULES", "CONTEPEC", 
                        "COPÁNDARO", "COTIJA", "CUITZEO", "CHARAPAN", "CHARO", "CHAVINDA", "CHERÁN", "CHILCHOTA", 
                        "CHINICUILA", "CHUCÁNDIRO", "CHURINTZIO", "CHURUMUCO", "ECUANDUREO", "EPITACIO HUERTA", 
                        "ERONGARÍCUARO", "GABRIEL ZAMORA", "HIDALGO", "LA HUACANA", "HUANDACAREO", "HUANIQUEO", "HUETAMO", 
                        "HUIRAMBA", "INDAPARAPEO", "IRIMBO", "IXTLÁN", "JACONA", "JIMÉNEZ", "JIQUILPAN", 
                        "JOSÉ SIXTO VERDUZCO", "JUÁREZ", "JUNGAPEO", "LAGUNILLAS", "MADERO", "MARAVATÍO", 
                        "MARCOS CASTELLANOS", "LÁZARO CÁRDENAS", "MORELIA", "MORELOS", "MÚGICA", "NAHUATZEN", "NOCUPÉTARO", 
                        "NUEVO PARANGARICUTIRO", "NUEVO URECHO", "NUMARÁN", "OCAMPO", "PAJACUARÁN", "PANINDÍCUARO", 
                        "PARÁCUARO", "PARACHO", "PÁTZCUARO", "PENJAMILLO", "PERIBÁN", "LA PIEDAD", "PURÉPERO", "PURUÁNDIRO", 
                        "QUERÉNDARO", "QUIROGA", "LOS REYES", "SAHUAYO", "SAN LUCAS", "SANTA ANA MAYA", 
                        "SALVADOR ESCALANTE", "SENGUIO", "SUSUPUATO", "TACÁMBARO", "TANCÍTARO", "TANGAMANDAPIO", 
                        "TANGANCÍCUARO", "TANHUATO", "TARETAN", "TARÍMBARO", "TEPALCATEPEC", "TINGAMBATO", "TINGÜINDÍN", 
                        "TIQUICHEO DE NICOLÁS ROMERO", "TLALPUJAHUA", "TLAZAZALCA", "TOCUMBO", "TUMBISCATÍO", "TURICATO", 
                        "TUXPAN", "TUZANTLA", "TZINTZUNTZAN", "TZITZIO", "URUAPAN", "VENUSTIANO CARRANZA", "VILLAMAR", 
                        "VISTA HERMOSA", "YURÉCUARO", "ZACAPU", "ZAMORA", "ZINÁPARO", "ZINAPÉCUARO", "ZIRACUARETIRO", 
                        "ZITÁCUARO" };
                    break;
                }
                case 16: // Morelos
                {
                    cities = new string[] { "AMACUZAC", "ATLATLAHUCAN", "AXOCHIAPAN", "AYALA", "COATLÁN DEL RÍO", "CUAUTLA", 
                        "CUERNAVACA", "EMILIANO ZAPATA", "HUITZILAC", "JANTETELCO", "JIUTEPEC", "JOJUTLA", 
                        "JONACATEPEC DE LEANDRO VALLE", "MAZATEPEC", "MIACATLÁN", "OCUITUCO", "PUENTE DE IXTLA", "TEMIXCO", 
                        "TEPALCINGO", "TEPOZTLÁN", "TETECALA", "TETELA DEL VOLCÁN", "TLALNEPANTLA", "TLALTIZAPÁN DE ZAPATA", 
                        "TLAQUILTENANGO", "TLAYACAPAN", "TOTOLAPAN", "XOCHITEPEC", "YAUTEPEC", "YECAPIXTLA", "ZACATEPEC", 
                        "ZACUALPAN DE AMILPAS", "TEMOAC" };
                    break;
                }
                case 17: // Nayarit
                {
                    cities = new string[] { "ACAPONETA", "AHUACATLÁN", "AMATLÁN DE CAÑAS", "COMPOSTELA", "HUAJICORI",
                        "IXTLÁN DEL RÍO", "JALA", "XALISCO", "DEL NAYAR", "ROSAMORADA", "RUÍZ", "SAN BLAS",
                        "SAN PEDRO LAGUNILLAS", "SANTA MARÍA DEL ORO", "SANTIAGO IXCUINTLA", "TECUALA", "TEPIC", "TUXPAN",
                        "LA YESCA", "BAHÍA DE BANDERAS" };
                   break;
                }
                case 18: // Nuevo Leon
                {
                    cities = new string[] { "ABASOLO", "AGUALEGUAS", "LOS ALDAMAS", "ALLENDE", "ANÁHUAC", "APODACA",
                    "ARAMBERRI", "BUSTAMANTE", "CADEREYTA JIMÉNEZ", "EL CARMEN", "CERRALVO", "CIÉNEGA DE FLORES", "CHINA",
                    "DOCTOR ARROYO", "DOCTOR COSS", "DOCTOR GONZÁLEZ", "GALEANA", "GARCÍA", "SAN PEDRO GARZA GARCÍA",
                    "GENERAL BRAVO", "GENERAL ESCOBEDO", "GENERAL TERÁN", "GENERAL TREVIÑO", "GENERAL ZARAGOZA",
                    "GENERAL ZUAZUA", "GUADALUPE", "LOS HERRERAS", "HIGUERAS", "HUALAHUISES", "ITURBIDE", "JUÁREZ",
                    "LAMPAZOS DE NARANJO", "LINARES", "MARÍN", "MELCHOR OCAMPO", "MIER Y NORIEGA", "MINA", "MONTEMORELOS", 
                        "MONTERREY", "PARÁS", "PESQUERÍA", "LOS RAMONES", "RAYONES", "SABINAS HIDALGO", "SALINAS VICTORIA", 
                        "SAN NICOLÁS DE LOS GARZA", "HIDALGO", "SANTA CATARINA", "SANTIAGO", "VALLECILLO", "VILLALDAMA" };
                    break;
                }
                case 19: // Oaxaca
                {
                    break;
                }
                case 20: // Puebla
                {
                    break;
                }
                case 21: // Querétaro
                {
                    cities = new string[] { "AMEALCO DE BONFIL", "PINAL DE AMOLES", "ARROYO SECO", "CADEREYTA DE MONTES", 
                        "COLÓN", "CORREGIDORA", "EZEQUIEL MONTES", "HUIMILPAN", "JALPAN DE SERRA", "LANDA DE MATAMOROS", 
                        "EL MARQUÉS", "PEDRO ESCOBEDO", "PEÑAMILLER", "QUERÉTARO", "SAN JOAQUÍN", "SAN JUAN DEL RÍO", 
                        "TEQUISQUIAPAN", "TOLIMÁN" };
                    break;
                }
                case 22: // Quintana Roo
                {
                    cities = new string[] { "COZUMEL", "FELIPE CARRILLO PUERTO", "ISLA MUJERES", "OTHÓN P. BLANCO", 
                        "BENITO JUÁREZ", "JOSÉ MARÍA MORELOS", "LÁZARO CÁRDENAS", "SOLIDARIDAD", "TULUM", "BACALAR", 
                        "PUERTO MORELOS" };
                    break;
                }
                case 23: // San Luis Potosí
                {
                    cities = new string[] { "AHUALULCO", "ALAQUINES", "AQUISMÓN", "ARMADILLO DE LOS INFANTE",
                        "AXTLA DE TERRAZAS", "CÁRDENAS", "CATORCE", "CEDRAL", "CERRITOS", "CERRO DE SAN PEDRO",
                        "CIUDAD DEL MAÍZ", "CIUDAD FERNÁNDEZ", "TANCANHUITZ", "CIUDAD VALLES", "COXCATLÁN", "CHARCAS",
                        "EBANO", "GUADALCÁZAR", "HUEHUETLÁN", "LAGUNILLAS", "MATEHUALA", "MATLAPA", "MEXQUITIC DE CARMONA",
                        "MOCTEZUMA", "EL NARANJO", "RAYÓN", "RIOVERDE", "SALINAS", "SAN ANTONIO", "SAN CIRO DE ACOSTA",
                        "SAN LUIS POTOSÍ", "SAN MARTÍN CHALCHICUAUTLA", "SAN NICOLÁS TOLENTINO", "SANTA CATARINA",
                        "SANTA MARÍA DEL RÍO", "SANTO DOMINGO", "SAN VICENTE TANCUAYALAB", "SOLEDAD DE GRACIANO SÁNCHEZ",
                        "TAMASOPO", "TAMAZUNCHALE", "TAMPACÁN", "TAMPAMOLÓN CORONA", "TAMUÍN", "TANLAJÁS",
                        "TANQUIÁN DE ESCOBEDO", "TIERRA NUEVA", "VANEGAS", "VENADO", "VILLA DE ARRIAGA", "VILLA DE ARISTA",
                        "VILLA DE GUADALUPE", "VILLA DE LA PAZ", "VILLA DE RAMOS", "VILLA DE REYES", "VILLA HIDALGO",
                        "VILLA JUÁREZ", "XILITLA", "ZARAGOZA" };
                    break;
                }
                case 24: // Sinaloa
                {
                    cities = new string[] { "AHOME", "ANGOSTURA", "BADIRAGUATO", "CONCORDIA", "COSALÁ", "CULIACÁN", 
                        "CHOIX", "ELOTA", "ESCUINAPA", "EL FUERTE", "GUASAVE", "MAZATLÁN", "MOCORITO", "ROSARIO", 
                        "SALVADOR ALVARADO", "SAN IGNACIO", "SINALOA", "NAVOLATO" };
                    break;
                }
                case 25: // Sonora 
                {
                    cities = new string[] { "ACONCHI", "AGUA PRIETA", "ALAMOS", "ALTAR", "ARIVECHI", "ARIZPE", "ATIL", 
                        "BACADÉHUACHI", "BACANORA", "BACERAC", "BACOACHI", "BÁCUM", "BANÁMICHI", "BAVIÁCORA", 
                        "BAVISPE", "BENJAMÍN HILL", "CABORCA", "CAJEME", "CANANEA", "CARBÓ", "LA COLORADA", "CUCURPE", 
                        "CUMPAS", "DIVISADEROS", "EMPALME", "ETCHOJOA", "FRONTERAS", "GRANADOS", "GUAYMAS", 
                        "HERMOSILLO", "HUACHINERA", "HUÁSABAS", "HUATABAMPO", "HUÉPAC", "IMURIS", "MAGDALENA", 
                        "MAZATÁN", "MOCTEZUMA", "NACO", "NÁCORI CHICO", "NACOZARI DE GARCÍA", "NAVOJOA", "NOGALES", 
                        "ONAVAS", "OPODEPE", "OQUITOA", "PITIQUITO", "PUERTO PEÑASCO", "QUIRIEGO", "RAYÓN", "ROSARIO", 
                        "SAHUARIPA", "SAN FELIPE DE JESÚS", "SAN JAVIER", "SAN LUIS RÍO COLORADO", 
                        "SAN MIGUEL DE HORCASITAS", "SAN PEDRO DE LA CUEVA", "SANTA ANA", "SANTA CRUZ", "SÁRIC", 
                        "SOYOPA", "SUAQUI GRANDE", "TEPACHE", "TRINCHERAS", "TUBUTAMA", "URES", "VILLA HIDALGO", 
                        "VILLA PESQUEIRA", "YÉCORA", "GENERAL PLUTARCO ELÍAS CALLES", "BENITO JUÁREZ", 
                        "SAN IGNACIO RÍO MUERTO" };
                    break;
                }
                case 26: // Tabasco
                {
                    cities = new string[] { "BALANCÁN", "CÁRDENAS", "CENTLA", "CENTRO", "COMALCALCO", "CUNDUACÁN", 
                        "EMILIANO ZAPATA", "HUIMANGUILLO", "JALAPA", "JALPA DE MÉNDEZ", "JONUTA", "MACUSPANA", "NACAJUCA", 
                        "PARAÍSO", "TACOTALPA", "TEAPA", "TENOSIQUE" };
                    break;
                }
                case 27: // Tamaulipas
                {
                    break;
                }
                case 28: // Tlaxcala
                {
                    break;
                }
                case 29: // Veracruz
                {
                    break;
                }
                case 30: // Yucatan
                {
                    break;
                }
                case 31: // Zacatecas
                {
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
                PrintError("TODOS LOS CAMPOS SON OBLIGATORIOS");
                return;
            }

            if (!RegexUtils.OnlyNumbers(txtServiceNumber.Text))
            {
                PrintError("EL NÚMERO DE SERVICIO SOLO ACEPTA CAMPOS NUMÉRICOS");
                return;
            }

            if (dao.ContractExists(txtMeterSerialNumber.Text, Convert.ToInt32(txtServiceNumber.Text)))
            {
                PrintError("EL NUMERO DE MEDIDOR YA EXISTE");
                return;
            }

            ContractDTO contract = FillContract();

            dao.Create(contract);

            FillDataGridView();

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "", MessageBoxButtons.OK);
        }

        private ContractDTO FillContract()
        {
            ContractDTO contract = new ContractDTO();
            DateTime today = DateTime.Now;
            contract.Contract_ID = Guid.NewGuid();
            contract.Client_ID = (Guid)dtgClients.Rows[dtgPrevIndex].Cells[0].Value;
            contract.First_Name = dtgClients.Rows[dtgPrevIndex].Cells[3].Value.ToString();
            contract.Father_Last_Name = dtgClients.Rows[dtgPrevIndex].Cells[4].Value.ToString();
            contract.Mother_Last_Name = dtgClients.Rows[dtgPrevIndex].Cells[5].Value.ToString();
            contract.Meter_Serial_Number = StringUtils.GetText(txtMeterSerialNumber);
            contract.Service_Number = Convert.ToInt32(StringUtils.GetText(txtServiceNumber));
            contract.State = cbState.Text;
            contract.City = cbCity.Text;
            contract.Suburb = txtSuburb.Text;
            contract.Street = txtStreet.Text;
            contract.Number = txtNumber.Text;
            contract.Postal_Code = txtPostalCode.Text;
            contract.Service = cbService.Text;
            contract.Start_Period_Date = new LocalDate(today.Year, today.Month, today.Day);
            return contract;
        }

        private void PrintError(string error)
        {
            pbWarningIcon.Visible = true;
            lblError.Visible = true;
            lblError.Text = error;
        }

        private void ClearForm()
        {
            txtMeterSerialNumber.Clear();
            txtServiceNumber.Clear();
            cbService.SelectedIndex = -1;
            cbState.SelectedIndex = -1;
            cbCity.SelectedIndex = -1;
            txtSuburb.Clear();
            txtStreet.Clear();
            txtNumber.Clear();
            txtPostalCode.Clear();
            dtpStartPeriodDate.Value = DateTime.Now;
        }

        private void FillDataGridView()
        {
            List<ContractDTO> contracts = dao.ReadClientContracts((Guid)dtgClients.Rows[dtgPrevIndex].Cells[0].Value);
            List<ContractDTG> dtgContracts = new List<ContractDTG>();
            foreach (var contract in contracts)
            {
                dtgContracts.Add(new ContractDTG(contract));
            }
            this.dtgContracts.DataSource = dtgContracts;
        }

        private void dtgClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dtgPrevIndex == index || index == -1)
            {
                txtClient.Clear();
                btnAccept.Enabled = false;
                dtgPrevIndex = -1;
                dtgContracts.DataSource = new List<ContractDTO>();
                //lbClients.ClearSelected();
                return;
            }
            else
            {
                dtgPrevIndex = index;
                txtClient.Text = dtgClients.Rows[index].Cells[1].Value.ToString();
                FillDataGridView();
                btnAccept.Enabled = true;
            }
        }
    }
}
