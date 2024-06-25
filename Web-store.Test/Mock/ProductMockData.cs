using Microsoft.Extensions.DependencyInjection;
using Web_store.Domain.Data;
using Web_store.Domain.Entities;

namespace Web_store.Test.Mock
{
    public class ProductMockData
    {
        public static async Task CreateProducts(Web_StoreAPIApplication application, bool criar)
        {
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;

                using (var DBContext = provider.GetRequiredService<DataContext>())
                {
                    await DBContext.Database.EnsureCreatedAsync();

                    if (criar) {
                        await DBContext.Products.AddAsync(new Product(
                            1,
                            "PLACA DE VÍDEO SAPPHIRE PULSE AMD RADEON RX 7900 XT",
                            "<r><n>Coprocessador gráfico<t>AMD RADEON RX 7900<r><n>Marca<t>Sapphire<r><n>Tamanho da memória RAM da placa gráfica<t>20<r><n>Velocidade do clock da GPU<t>2075 MHz<r><n>Interface de saída de vídeo<t>DisplayPort, HDMI",
                            5379.99,
                            50,
                            true,
                            1
                        ));

                        await DBContext.Products.AddAsync(new Product(
                            2,
                            "Câmera PTZ, câmera de sala de conferência 20X com saídas de transmissão 3G-SDI, USB3.0, HDMI e IP",
                            "Marca<t>HCSTVCON<r><n>Tecnologia do sensor fotográfico<t>CMOS<r><n>Resolução de captura de vídeo<t>1080p<r><n>Tipo de memória Flash<t>Micro SD<r><n>Tamanho da tela<t>2,7 Polegadas<r><n>Tecnologia de conectividade<t>Com fio<r><n>Cor<t>HDMI/USB/SDI/LAN - HD590<r><n>Zoom óptico<t>20 x<r><n>Tipo de lente<t>Zoom<r><n>Adequação do controle por rádio<t>Videoconferência, treinamento remoto, transmissões ao vivo da igreja",
                            2429.10, 
                            79, 
                            true,
                            2
                        ));

                        await DBContext.Products.AddAsync(new Product(
                            3,
                            "Notebook Acer Nitro V15 ANV15-51-58AZ 13ª Geração Intel Core i5-13420H, 8GB RAM, 512GB SSD, NVIDIA RTX 3050, 15.6\" FHD LED IPS 144Hz, Windows 11",
                            "Marca<t>ACER<r><n>Nome do modelo<t>Nitro V15<r><n>Tamanho da tela<t>15,6 Polegadas<r><n>Cor<t>preto<r><n>Tamanho do disco rígido<t>512 GB<r><n>Modelo da CPU<t>Intel Core i5<r><n>Tamanho instalado da memória RAM<t>8 GB<r><n>Sistema operacional<t>Windows 11 Home<r><n>Características especiais<t>Sistema Operacional Windows 11 • Tecnologia DTS® X: Ultra Áudio, Habilitado para upgrades, Teclado retroiluminado na cor branca com ajuste de intensidade, • Tecla de atalho Nitro Sense, 512 GB de armazenamento em SSD NVMeSistema Operacional Windows 11",
                            4499.98,
                            44,
                            true,
                            1
                        ));

                        await DBContext.Products.AddAsync(new Product(
                            4,
                            "Mouse SLIM recarregável Bluetooth Para todos celulares, tablets e notebooks da Samsung (Rosa)",
                            "Marca<t>I NEW<r><n>Cor<t>Rosa<r><n>Tecnologia de conectividade<t>Bluetooth<r><n>Tecnologia de detecção de movimento<t>Óptico<r><n>Orientação manual<t>Ambidestro<r><n>",
                            139.50,
                            455,
                            true,
                            2
                        ));

                        await DBContext.Products.AddAsync(new Product(
                            5,
                            "Teclado Mecanico Gamer Fizz Rainbow Preto Switch Marrom",
                            "Marca<t>Redragon<r><n>Dispositivos compatíveis<t>PC<r><n>Tecnologia de conectividade<t>USB-A<r><n>Descrição do teclado<t>Mecânico<r><n>Adequação do controle por rádio<t>Jogo",
                            134.91,
                            342,
                            true,
                            1
                        ));

                        await DBContext.Products.AddAsync(new Product(
                            6,
                            "Water Cooler Gamer Fan Ventoinha 120mm Rgb Pc Processador CPU Master Intel AMD",
                            "Dimensões do produto<t>12C x 12L x 2,5A centímetros<r><n>Marca<t>Revenger<r><n>Tipo de conector de energia<t>4 pinos<r><n>Tensão<t>12 Volts<r><n>Método de refrigeração<t>Água",
                            222.29,
                            120,
                            true,
                            2
                        ));

                        await DBContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
