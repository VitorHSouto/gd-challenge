using FluentMigrator;
using System.Globalization;

namespace gd_api.Domain.Migrations
{
    [Migration(202402031810)]
    public class Migration_202402031810 : FluentMigrator.Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
#region company1
            var company1 = InsertCompany("Restaurante Delícia", "Especializado em culinária internacional", "9876-5432",
                InsertAddress("Rua das Flores", "456", "Cidade Grande", "Estado ABC", "54321-098")
            );

            InsertProduct("Prato Especial", "Uma deliciosa combinação de sabores internacionais", 29.99m, company1);
            InsertProduct("Menu Vegetariano", "Opções saudáveis e saborosas para os amantes de vegetais", 24.99m, company1);
            InsertProduct("Sobremesa Gourmet", "Finalize sua refeição com uma sobremesa irresistível", 12.99m, company1);

#endregion

#region company2
            var company2 = InsertCompany("Bistrô Charmoso", "Oferecendo pratos gourmet com toque artístico", "1234-5678",
                          InsertAddress("Avenida Principal", "789", "Cidade Pequena", "Estado XYZ", "98765-432"));

            InsertProduct("Menu Degustação", "Experimente uma seleção exclusiva de pratos gourmet", 49.99m, company2);
            InsertProduct("Prato do Chef", "A especialidade da casa preparada pelo chef renomado", 34.99m, company2);
#endregion

#region company3
            var company3 = InsertCompany("Café do Bairro", "Ambiente acolhedor com variedade de cafés e doces", "4567-8901",
                          InsertAddress("Rua da Praça", "101", "Cidade Pequena", "Estado XYZ", "56789-012"));

            InsertProduct("Café Espresso", "Uma xícara de café forte e encorpado", 5.99m, company3);
            InsertProduct("Bolo de Chocolate", "Delicioso bolo de chocolate feito na casa", 8.99m, company3);
            InsertProduct("Cappuccino Especial", "Cappuccino cremoso com toque de canela", 7.49m, company3);
            InsertProduct("Torta de Frutas", "Torta fresca com uma variedade de frutas da estação", 12.99m, company3);
            InsertProduct("Pão de Queijo Gourmet", "Pão de queijo recheado com queijo especial", 6.99m, company3);
#endregion

#region company4
            var company4 = InsertCompany("Pizzaria Bella Napoli", "Autênticas pizzas napolitanas com ingredientes frescos", "8765-4321",
                          InsertAddress("Avenida Central", "222", "Cidade Grande", "Estado ABC", "23456-789"));

            InsertProduct("Pizza Margherita", "Clássica pizza napolitana com molho de tomate, mussarela e manjericão", 29.99m, company4);
            InsertProduct("Calzone Recheado", "Calzone assado recheado com presunto, queijo e cogumelos", 18.99m, company4);
            InsertProduct("Lasanha à Bolonhesa", "Lasanha gratinada com molho à bolonhesa e queijo derretido", 22.99m, company4);
#endregion

#region company5
            var company5 = InsertCompany("Sushi Express", "Sabores autênticos do Japão com entrega rápida", "3456-7890",
                      InsertAddress("Avenida dos Sabores", "555", "Cidade Sushi", "Estado JPN", "34567-890"));

            InsertProduct("Sashimi Variado", "Seleção de fatias finas de peixe fresco", 38.99m, company5);
            InsertProduct("Temaki Especial", "Temaki enrolado à mão com ingredientes frescos e saborosos", 15.99m, company5);
            InsertProduct("Combinado de Sushi", "Assortimento de sushis variados, perfeito para compartilhar", 48.99m, company5);
            InsertProduct("Yakitori de Frango", "Espetinhos de frango grelhados com molho teriyaki", 12.99m, company5);
#endregion
        }

        private Guid InsertCompany(String name, String description, String phoneNumber, Guid addressId)
        {
            var id = Guid.NewGuid();
            var now = DateTime.UtcNow;

            Execute.Sql(@$"INSERT INTO company
                (id, createdat, updatedat, active, name, phone, description, addressid)
                VALUES('{id}', '{now}', '{now}', true, '{name}', '{phoneNumber}', '{description}', '{addressId}')");

            return id;
        }

        private Guid InsertAddress(string street, string number, string city, string state, string zipcode)
        {
            var id = Guid.NewGuid();
            var now = DateTime.UtcNow;

            Execute.Sql($@"INSERT INTO address
                    (id, createdat, updatedat, active, street, number, city, state, zipcode)
                    VALUES('{id}', '{now}', '{now}', true, '{street}', '{number}', '{city}', '{state}', '{zipcode}')");

            return id;
        }

        private void InsertProduct(string name, string description, decimal price, Guid companyId)
        {
            var id = Guid.NewGuid();
            var now = DateTime.UtcNow;

            Execute.Sql($@"INSERT INTO product
                    (id, createdat, updatedat, active, name, description, price, companyId)
                    VALUES('{id}', '{now}', '{now}', true, '{name}', '{description}', '{price.ToString(CultureInfo.InvariantCulture)}', '{companyId}')");
        }


    }
}
