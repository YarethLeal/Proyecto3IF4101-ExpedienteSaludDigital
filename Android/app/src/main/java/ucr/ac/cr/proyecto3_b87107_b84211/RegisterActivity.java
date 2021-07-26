package ucr.ac.cr.proyecto3_b87107_b84211;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import java.util.HashMap;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import ucr.ac.cr.proyecto3_b87107_b84211.interfaces.UsuarioAPI;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Usuario;

public class RegisterActivity extends AppCompatActivity {
    EditText cedula;
    EditText password;
    Button register;
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        cedula=findViewById(R.id.cedulaForm);
        password=findViewById(R.id.passwordForm);
        register=findViewById(R.id.register);

        register.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(!cedula.getText().toString().isEmpty() && !password.getText().toString().isEmpty()){
                    register(cedula.getText().toString(),password.getText().toString());
                }
                else{
                    Toast.makeText(RegisterActivity.this,"Complete los espacios",Toast.LENGTH_SHORT).show();
                }
            }
        });
    }

    private void register(String cedula,String contrasena){
        Retrofit retrofit=new Retrofit.Builder().baseUrl("https://api-b87107-b84211.azurewebsites.net/")
                .addConverterFactory(GsonConverterFactory.create()).build();
        UsuarioAPI usuarioAPI=retrofit.create(UsuarioAPI.class);
        Call<String> call=usuarioAPI.register(cedula, contrasena,"1");
        call.enqueue(new Callback<String>() {
            @Override
            public void onResponse(Call<String> call, Response<String> response) {
                try {
                    if(response.isSuccessful()){
                        String respuesta = response.body();
                        if(respuesta.contentEquals("REGISTRO EXITOSO")){
                            Toast.makeText(RegisterActivity.this,respuesta,Toast.LENGTH_SHORT).show();
                            Intent intentLogin = new Intent(getApplicationContext(), LoginActivity.class);
                            startActivity(intentLogin);
                        }else{
                            Toast.makeText(RegisterActivity.this,response.body(),Toast.LENGTH_SHORT).show();
                        }
                    }
                }catch (Exception ex){
                    Toast.makeText(RegisterActivity.this,ex.getMessage(),Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<String> call, Throwable t) {
                Toast.makeText(RegisterActivity.this,t.getMessage(),Toast.LENGTH_SHORT).show();
            }
        });
    }
}
