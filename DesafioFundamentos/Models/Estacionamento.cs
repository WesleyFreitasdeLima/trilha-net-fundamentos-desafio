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
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");

                string? placa = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(placa))
                {
                    Console.WriteLine("Placa inválida! Tente novamente.");
                    continue;
                }

                veiculos.Add(placa);

                break;
            }
        }

        public void RemoverVeiculo()
        {
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para remover:");

                string? placa = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(placa))
                {
                    Console.WriteLine("Placa inválida! Tente novamente.");
                    continue;
                }

                int veiculoIndex = BuscarVeiculo(placa);

                if (veiculoIndex == -1)
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                    continue;
                }

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horasEstacionado = 0;

                decimal valorTotal = 0;

                if (!(int.TryParse(Console.ReadLine(), out horasEstacionado) && horasEstacionado >= 0))
                {
                    Console.WriteLine("Valor de horas estacionadas inválido! Tente novamente.");
                    continue;
                }

                valorTotal = ObterPrecoTotal(horasEstacionado);

                veiculos.RemoveAt(veiculoIndex);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

                break;
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private int BuscarVeiculo(string placa)
        {
            return veiculos.FindIndex(placaVeiculoEstacionado => placaVeiculoEstacionado.ToUpper() == placa.ToUpper());
        }

        private double ObterPrecoTotal(int horasEstacionado)
        {
            return (horasEstacionado * precoPorHora) + precoInicial;
        }

    }
}
