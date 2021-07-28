package ucr.ac.cr.proyecto3_b87107_b84211;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
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

public class DatosActivity extends AppCompatActivity {
    TextView cedula;
    TextView nombre;
    TextView edad;
    TextView tpSangre;
    EditText estado;
    EditText telefono;
    EditText domicilio;
    Button btnEditar;
    ImageButton btnSalir;
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_datos);
        Bundle bundle = getIntent().getExtras();
        String cedulaUser = bundle.getString("userId");
        //Declarar
        cedula=findViewById(R.id.txtCedula);
        nombre = findViewById(R.id.txtNombre);
        edad = findViewById(R.id.txtEdad);
        tpSangre = findViewById(R.id.txtSangre);
        estado = findViewById(R.id.txtEstado);
        telefono = findViewById(R.id.txtTelefono);
        domicilio = findViewById(R.id.txtDireccion);
        btnEditar = findViewById(R.id.btnUpdate);
        btnSalir = findViewById(R.id.exitBtn);

        cedula.setText(cedulaUser);
        datosUsuario(cedulaUser);
        btnEditar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                actualizaDatos();
            }
        });
        btnSalir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intentLogin = new Intent(getApplicationContext(), LoginActivity.class);
                startActivity(intentLogin);
            }
        });
    }
    private void datosUsuario(String cedula){
        Retrofit retrofit=new Retrofit.Builder().baseUrl("https://api-b87107-b84211.azurewebsites.net/")
                .addConverterFactory(GsonConverterFactory.create()).build();
        UsuarioAPI usuarioAPI=retrofit.create(UsuarioAPI.class);
        Call<Usuario> call=usuarioAPI.datosUser(cedula);
        call.enqueue(new Callback<Usuario>() {
            @Override
            public void onResponse(Call<Usuario> call, Response<Usuario> response) {
                try {
                    if(response.isSuccessful()){
                        Usuario respuesta = response.body();
                        nombre.setText(respuesta.getNombre());
                        edad.setText(String.valueOf(respuesta.getEdad()));
                        tpSangre.setText(respuesta.getTpSangre());
                        estado.setText(respuesta.getEstado_civil());
                        telefono.setText(String.valueOf(respuesta.getTelefono()));
                        domicilio.setText(respuesta.getDomicilio());
                    }
                }catch (Exception ex){
                    Toast.makeText(DatosActivity.this,ex.getMessage(),Toast.LENGTH_SHORT).show();
                }
            }

            @Override
           public void onFailure(Call<Usuario> call, Throwable t) {
                Toast.makeText(DatosActivity.this,"Error de conexion",Toast.LENGTH_SHORT).show();
            }
       });
    }
    private void actualizaDatos(){
        Retrofit retrofit=new Retrofit.Builder().baseUrl("https://api-b87107-b84211.azurewebsites.net/")
                .addConverterFactory(GsonConverterFactory.create()).build();
        UsuarioAPI usuarioAPI=retrofit.create(UsuarioAPI.class);
        Usuario user = new Usuario(estado.getText().toString(),
                Integer.parseInt(telefono.getText().toString()),domicilio.getText().toString());
        Call<String> call=usuarioAPI.actualiza(cedula.getText().toString(),user);
        call.enqueue(new Callback<String>() {
            @Override
            public void onResponse(Call<String> call, Response<String> response) {
                try {
                    if(response.isSuccessful()){
                        datosUsuario(cedula.getText().toString());
                    }
                }catch (Exception ex){
                    Toast.makeText(DatosActivity.this,ex.getMessage(),Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<String> call, Throwable t) {
                Toast.makeText(DatosActivity.this,"Error de conexion",Toast.LENGTH_SHORT).show();
            }
        });
    }
}
