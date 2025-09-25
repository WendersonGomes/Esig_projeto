using Esig_projeto.App_Code.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public class PessoaRepository
{
    public List<PessoaSalario> ListarSalariosComBonus()
    {
        var lista = new List<PessoaSalario>();

        using (var conn = DBConexao.GetConexao())
        {
            conn.Open();

            using (var cmd = new MySqlCommand("calcular_salarios_com_bonus", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }

            string sql = "SELECT pessoa_id, pessoa_nome, cargo_nome, salario FROM pessoa_salario ORDER BY pessoa_id ASC";
            using (var cmd = new MySqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new PessoaSalario
                    {
                        PessoaId = reader.GetInt32("pessoa_id"),
                        PessoaNome = reader.GetString("pessoa_nome"),
                        CargoNome = reader.GetString("cargo_nome"),
                        Salario = reader.GetDecimal("salario")
                    });
                }
            }
        }

        return lista;
    }

    public List<PessoaSalario> ListarSalariosSemBonus()
    {
        var lista = new List<PessoaSalario>();

        using (var conn = DBConexao.GetConexao())
        {
            conn.Open();

            using (var cmd = new MySqlCommand("calcular_salarios", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }

            string sql = "SELECT pessoa_id, pessoa_nome, cargo_nome, salario FROM pessoa_salario ORDER BY pessoa_id ASC";
            using (var cmd = new MySqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new PessoaSalario
                    {
                        PessoaId = reader.GetInt32("pessoa_id"),
                        PessoaNome = reader.GetString("pessoa_nome"),
                        CargoNome = reader.GetString("cargo_nome"),
                        Salario = reader.GetDecimal("salario")
                    });
                }
            }
        }

        return lista;
    }

    public int ObterProximoId()
    {
        using (var conn = DBConexao.GetConexao())
        {
            conn.Open();
            string sql = "SELECT MAX(pessoa_id) FROM pessoa";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                    return Convert.ToInt32(result) + 1;
                else
                    return 1;
            }
        }
    }

    public void Inserir(Pessoa pessoa)
    {
        pessoa.PessoaId = ObterProximoId();
        using (var conn = DBConexao.GetConexao())
        {
            conn.Open();
            string sql = @"INSERT INTO pessoa (pessoa_id, nome, cidade, email, cep, endereco, pais, usuario, telefone, data_nascimento, cargo_id)
                           VALUES (@id, @nome, @cidade, @email, @cep, @endereco, @pais, @usuario, @telefone, @data, @cargo)";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", pessoa.PessoaId);
                cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                cmd.Parameters.AddWithValue("@email", pessoa.Email);
                cmd.Parameters.AddWithValue("@cep", pessoa.CEP);
                cmd.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                cmd.Parameters.AddWithValue("@pais", pessoa.Pais);
                cmd.Parameters.AddWithValue("@usuario", pessoa.Usuario);
                cmd.Parameters.AddWithValue("@telefone", pessoa.Telefone);
                cmd.Parameters.AddWithValue("@data", pessoa.DataNascimento);
                cmd.Parameters.AddWithValue("@cargo", pessoa.CargoId);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Atualizar(Pessoa pessoa)
    {
        using (var conn = DBConexao.GetConexao())
        {
            conn.Open();
            string sql = @"UPDATE pessoa SET nome=@nome, cidade=@cidade, email=@email, cep=@cep,
                           endereco=@endereco, pais=@pais, usuario=@usuario, telefone=@telefone,
                           data_nascimento=@data, cargo_id=@cargo
                           WHERE pessoa_id=@id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", pessoa.PessoaId);
                cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                cmd.Parameters.AddWithValue("@email", pessoa.Email);
                cmd.Parameters.AddWithValue("@cep", pessoa.CEP);
                cmd.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                cmd.Parameters.AddWithValue("@pais", pessoa.Pais);
                cmd.Parameters.AddWithValue("@usuario", pessoa.Usuario);
                cmd.Parameters.AddWithValue("@telefone", pessoa.Telefone);
                cmd.Parameters.AddWithValue("@data", pessoa.DataNascimento);
                cmd.Parameters.AddWithValue("@cargo", pessoa.CargoId);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Excluir(int pessoaId)
    {
        using (var conn = DBConexao.GetConexao())
        {
            conn.Open();
            string sql = "DELETE FROM pessoa WHERE pessoa_id=@id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", pessoaId);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Pessoa ObterPorId(int pessoaId)
    {
        using (var conn = DBConexao.GetConexao())
        {
            conn.Open();
            string sql = "SELECT * FROM pessoa WHERE pessoa_id=@id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", pessoaId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Pessoa
                        {
                            PessoaId = reader.GetInt32("pessoa_id"),
                            Nome = reader.GetString("nome"),
                            Cidade = reader["cidade"]?.ToString(),
                            Email = reader["email"]?.ToString(),
                            CEP = reader["cep"]?.ToString(),
                            Endereco = reader["endereco"]?.ToString(),
                            Pais = reader["pais"]?.ToString(),
                            Usuario = reader["usuario"]?.ToString(),
                            Telefone = reader["telefone"]?.ToString(),
                            DataNascimento = reader["data_nascimento"] == DBNull.Value ? DateTime.MinValue : reader.GetDateTime("data_nascimento"),
                            CargoId = reader.GetInt32("cargo_id")
                        };
                    }
                    return null;
                }
            }
        }
    }

    public List<Cargo> ListarCargos()
    {
        var lista = new List<Cargo>();
        using (var conn = DBConexao.GetConexao())
        {
            conn.Open();
            string sql = "SELECT * FROM cargo";
            using (var cmd = new MySqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new Cargo
                    {
                        CargoId = reader.GetInt32("cargo_id"),
                        CargoNome = reader.GetString("cargo_nome"),
                        Salario = reader.GetDecimal("salario")
                    });
                }
            }
        }
        return lista;
    }
}