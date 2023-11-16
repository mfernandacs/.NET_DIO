namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para estacionar:");

            try
            {
                string placa = Console.ReadLine();

                if (!string.IsNullOrEmpty(placa))
                {
                    if (!veiculos.Contains(placa))
                    {
                        veiculos.Add(placa);
                        Console.WriteLine("Veículo adicionado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Este veículo já foi adicionado.");
                    }
                }
                else
                {
                    Console.WriteLine("Placa inválida. Tente novamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                string inputHoras = Console.ReadLine().Trim();

                if (int.TryParse(inputHoras, out int horas))
                {
                    decimal valorTotal = this.precoInicial + this.precoPorHora * horas;

                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Caracter inválido digitado. Inicie novamente para remover o veiculo");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
