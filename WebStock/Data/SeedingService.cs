using System.Collections.Generic;
using WebStock.Models;

namespace WebStock.Data
{
    public class SeedingService
    {
        private readonly WebStockContext _context;
        public SeedingService(WebStockContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (_context.EntryType.Any() && _context.ExitType.Any() && _context.AdjustmentReason.Any() && _context.Customer.Any() && _context.Product.Any())
            {
                return;
            }

            List<EntryType> entries = new List<EntryType>();
            entries.Add(new EntryType { Name = "Purchase" });
            entries.Add(new EntryType { Name = "Return" });
            entries.Add(new EntryType { Name = "Adjustment" });

            List<ExitType> exits = new List<ExitType>();
            exits.Add(new ExitType { Name = "Sale" });
            exits.Add(new ExitType { Name = "Transfer" });
            exits.Add(new ExitType { Name = "Adjustment" });

            List<AdjustmentReason> adjustmentReasons = new List<AdjustmentReason>();
            adjustmentReasons.Add(new AdjustmentReason { Reason = "Lost" });
            adjustmentReasons.Add(new AdjustmentReason { Reason = "Damage" });
            adjustmentReasons.Add(new AdjustmentReason { Reason = "Manual Adjustment" });
            adjustmentReasons.Add(new AdjustmentReason { Reason = "Inventory Correction" });

            List<Category> categories = new List<Category>();
            categories.Add(new Category { Name = "Eletrônicos", Description = "Produtos eletrônicos, como celulares, tablets e computadores" });
            categories.Add(new Category { Name = "Vestuário", Description = "Roupas, calçados e acessórios de moda" });
            categories.Add(new Category { Name = "Alimentos", Description = "Comidas e bebidas, incluindo produtos perecíveis e não perecíveis" });
            categories.Add(new Category { Name = "Móveis", Description = "Móveis para casa e escritório, como mesas, cadeiras e sofás" });
            categories.Add(new Category { Name = "Livros", Description = "Livros de ficção, não ficção e educativos" });
            categories.Add(new Category { Name = "Brinquedos", Description = "Brinquedos e jogos para crianças de todas as idades" });
            categories.Add(new Category { Name = "Ferramentas", Description = "Ferramentas manuais e elétricas para construção e reparo" });
            categories.Add(new Category { Name = "Beleza e Saúde", Description = "Produtos de higiene pessoal, cosméticos e cuidados com a saúde" });
            categories.Add(new Category { Name = "Esporte e Lazer", Description = "Equipamentos esportivos, roupas e acessórios para atividades ao ar livre" });
            categories.Add(new Category { Name = "Automotivo", Description = "Peças, acessórios e ferramentas para veículos automotores" });

            List<Customer> customer = new List<Customer>();
            customer.Add(new Customer { Name = "João Silva", DDD = 11, PhoneNumber = "98765-4321", Address = "Rua das Flores, 123, São Paulo, SP", TaxId = "123.456.789-00" });
            customer.Add(new Customer { Name = "Maria Oliveira", DDD = 21, PhoneNumber = "96543-2109", Address = "Avenida Atlântica, 456, Rio de Janeiro, RJ", TaxId = "987.654.321-00" });
            customer.Add(new Customer { Name = "Carlos Pereira", DDD = 31, PhoneNumber = "91234-5678", Address = "Rua dos Cravos, 789, Belo Horizonte, MG", TaxId = "321.654.987-00" });
            customer.Add(new Customer { Name = "Ana Souza", DDD = 41, PhoneNumber = "99876-5432", Address = "Praça das Palmeiras, 321, Curitiba, PR", TaxId = "456.123.789-00" });
            customer.Add(new Customer { Name = "Pedro Lima", DDD = 61, PhoneNumber = "99988-7766", Address = "Setor Comercial Sul, Brasília, DF", TaxId = "654.987.321-00" });

            List<Product> products = new List<Product>();
            products.Add(new Product{ Name = "Smartphone", Description = "Celular com 128GB de memória interna e câmera de 48MP", PurchasePrice = 1200.00, SalePrice = 1800.00, StockQuantity = 50, ExpirationDate = DateTime.MaxValue, Category = categories.FirstOrDefault(x => x.Name == "Eletrônicos")});
            products.Add(new Product { Name = "Notebook", Description = "Notebook Core i7 com 16GB RAM e 512GB SSD", PurchasePrice = 3000.00, SalePrice = 4500.00, StockQuantity = 30, ExpirationDate = DateTime.MaxValue, Category = categories.FirstOrDefault(x => x.Name == "Eletrônicos")});
            products.Add(new Product { Name = "Camisa Polo", Description = "Camisa polo 100% algodão", PurchasePrice = 40.00, SalePrice = 80.00, StockQuantity = 100, ExpirationDate = DateTime.MaxValue, Category = categories.FirstOrDefault(x => x.Name == "Vestuário")});
            products.Add(new Product { Name = "Sofá 3 Lugares", Description = "Sofá confortável com revestimento em tecido", PurchasePrice = 500.00, SalePrice = 1200.00, StockQuantity = 15, ExpirationDate = DateTime.MaxValue, Category = categories.FirstOrDefault(x => x.Name == "Móveis")});
            products.Add(new Product { Name = "Livro: C# Avançado", Description = "Guia completo para programadores avançados em C#", PurchasePrice = 80.00, SalePrice = 120.00, StockQuantity = 40, ExpirationDate = DateTime.MaxValue, Category = categories.FirstOrDefault(x => x.Name == "Livros")});
            products.Add(new Product { Name = "Fones de Ouvido", Description = "Fones de ouvido Bluetooth com cancelamento de ruído", PurchasePrice = 150.00, SalePrice = 250.00, StockQuantity = 80, ExpirationDate = DateTime.MaxValue, Category = categories.FirstOrDefault(x => x.Name == "Eletrônicos")});
            products.Add(new Product { Name = "Cadeira Gamer", Description = "Cadeira ergonômica para jogos, ajuste de altura e reclinável", PurchasePrice = 350.00, SalePrice = 700.00, StockQuantity = 25, ExpirationDate = DateTime.MaxValue, Category = categories.FirstOrDefault(x => x.Name == "Móveis")});
            products.Add(new Product { Name = "Camiseta Estampada", Description = "Camiseta de algodão com estampa criativa", PurchasePrice = 30.00, SalePrice = 50.00, StockQuantity = 120, ExpirationDate = DateTime.MaxValue, Category = categories.FirstOrDefault(x => x.Name == "Vestuário")});
            products.Add(new Product { Name = "Relógio Digital", Description = "Relógio digital com cronômetro e alarme", PurchasePrice = 80.00, SalePrice = 120.00, StockQuantity = 60, ExpirationDate = DateTime.MaxValue, Category = categories.FirstOrDefault(x => x.Name == "Eletrônicos")});
            products.Add(new Product { Name = "Headset para PC", Description = "Headset com microfone ajustável e áudio surround", PurchasePrice = 200.00, SalePrice = 350.00, StockQuantity = 45, ExpirationDate = DateTime.MaxValue, Category = categories.FirstOrDefault(x => x.Name == "Eletrônicos")});

            foreach (var itens in entries)
            {
                if (!_context.EntryType.Any(x => x.Name == itens.Name))
                {
                    await _context.EntryType.AddAsync(itens);
                }
            }

            foreach(var itens in exits)
            {
                if (!_context.ExitType.Any(x => x.Name == itens.Name))
                {
                    await _context.ExitType.AddAsync(itens);
                }
            }

            foreach (var itens in adjustmentReasons)
            {
                if (!_context.AdjustmentReason.Any(x => x.Reason == itens.Reason))
                {
                    await _context.AdjustmentReason.AddAsync(itens);
                }
            }

            foreach (var itens in categories)
            {
                if (!_context.Category.Any(x => x.Name == itens.Name))
                {
                    await _context.Category.AddAsync(itens);
                }
            }

            foreach (var itens in customer)
            {
                if (!_context.Customer.Any(x => x.TaxId == itens.TaxId))
                {
                    await _context.Customer.AddAsync(itens);
                }
            }

            foreach (var itens in products)
            {
                if (!_context.Product.Any(x => x.Name == itens.Name && x.Category.Name == itens.Category.Name))
                {
                    await _context.Product.AddAsync(itens);
                }
            }

            await _context.SaveChangesAsync();

        }
    }
}
