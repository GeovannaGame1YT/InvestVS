using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

class Banco
{
    readonly MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;User id=root;database=invest;password=master");

    public DataRow CommandRow(String sql)
    {
        try
        {
            return ExecutarQueryRetorna(sql).Rows[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Login(string user, string password)
    {
        try
        {
            if (objcon.State == ConnectionState.Closed)
            {
                objcon.Open();
            }
            MySqlCommand objcmd = new MySqlCommand("Select usuario, senha from usuario where usuario = '" + user + "' and senha = '" + password + "';", objcon);
            MySqlDataReader dr = objcmd.ExecuteReader();

            if (dr.HasRows)
            {
                //Logado
                objcon.Close();
                dr.Close();
                return true;

            }
            else
            {
                dr.Close();
                objcon.Close();
                //ERRADO
                MessageBox.Show("Usuário ou senha inválidos.");
                return false;
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show("Não foi possivel se comunicar com o banco de dados. Motivo:" + ex);
            return false;
        }
    }

    public void ExecutarQuery(String query)
    {
        try
        {
            if (objcon.State == ConnectionState.Closed)
            {
                objcon.Open();
            }

            MySqlCommand objcmd = new MySqlCommand(query, objcon);
            objcmd.ExecuteNonQuery();

            if(objcon.State == ConnectionState.Open)
            {
                objcon.Close();
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao executar o processo, contato o administrador" + ex);
        }

    }

    public DataTable ExecutarQueryRetorna(String query)
    {
        try
        {
            if (objcon.State == ConnectionState.Closed)
            {
                objcon.Open();
            }

            MySqlCommand objcmd = new MySqlCommand(query, objcon);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = objcmd;
            objcmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (objcon.State == ConnectionState.Open)
            {
                objcon.Close();
            }
            return dt;
            

        }
        catch
        {
            return null;
        }

    }


    public void FinalizarCadastro(String Nome, String Usuario, String Senha)
    {
        try
        {
            if (objcon.State == ConnectionState.Closed)
            {
                objcon.Open();
            }

            MySqlCommand objcmd = new MySqlCommand("INSERT INTO USUARIO (nome, usuario, senha) VALUES ('" + Nome + "','" + Usuario + "','" + Senha + "')" ,objcon);
            objcmd.ExecuteNonQuery();

            MessageBox.Show("Usuario cadastrado com sucesso.");
            
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao finalizar o cadastro, entre em contato com o Administrador" + ex);
        }
    }
}

