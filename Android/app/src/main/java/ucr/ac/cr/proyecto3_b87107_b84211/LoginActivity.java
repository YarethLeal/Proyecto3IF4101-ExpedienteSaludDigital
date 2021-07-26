package ucr.ac.cr.proyecto3_b87107_b84211;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import ucr.ac.cr.proyecto3_b87107_b84211.interfaces.UsuarioAPI;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Usuario;

public class LoginActivity extends AppCompatActivity {
    EditText edtCedula;
    EditText edtContrasena;
    TextView tvRegisterF;
    Button btnLogin;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        edtCedula=findViewById(R.id.usernameLogin);
        edtContrasena=findViewById(R.id.passwordLogin);
        tvRegisterF=findViewById(R.id.registerForm);
        btnLogin=findViewById(R.id.loginButton);

        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                login(edtCedula.getText().toString(),edtContrasena.getText().toString());
            }
        });
    }

    private void login(String cedula,String contrasena){
        Retrofit retrofit=new Retrofit.Builder().baseUrl("https://api-b87107-b84211.azurewebsites.net/")
                .addConverterFactory(GsonConverterFactory.create()).build();
        UsuarioAPI usuarioAPI=retrofit.create(UsuarioAPI.class);
        Call<Integer> call=usuarioAPI.find(cedula,contrasena);
        call.enqueue(new Callback<Integer>() {
            @Override
            public void onResponse(Call<Integer> call, Response<Integer> response) {
                try {
                    if(response.isSuccessful()){
                        int respuesta = response.body();
                        if(respuesta == 1){
                            Intent intentMain = new Intent(getApplicationContext(), MainActivity.class);
                            intentMain.putExtra("userId",edtCedula.getText().toString());
                            startActivity(intentMain);
                        }else{
                            Toast.makeText(LoginActivity.this,"Error:Verifique los datos",Toast.LENGTH_SHORT).show();
                        }
                    }
                }catch (Exception ex){
                    Toast.makeText(LoginActivity.this,ex.getMessage(),Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<Integer> call, Throwable t) {
                Toast.makeText(LoginActivity.this,"Error de conexion",Toast.LENGTH_SHORT).show();
            }
        });
    }
}
