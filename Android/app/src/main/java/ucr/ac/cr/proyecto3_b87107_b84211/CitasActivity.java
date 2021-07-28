package ucr.ac.cr.proyecto3_b87107_b84211;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import ucr.ac.cr.proyecto3_b87107_b84211.adapters.ListaAlergiasAdapter;
import ucr.ac.cr.proyecto3_b87107_b84211.adapters.ListaCitasAdaptar;
import ucr.ac.cr.proyecto3_b87107_b84211.interfaces.HistorialMedicoApi;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Alergias;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Citas;

public class CitasActivity extends AppCompatActivity {
    TextView cedulaId;
    ImageButton btnSalir;

    private RecyclerView listaCitasRecycler;
    private List<Citas> citas = new ArrayList<>();
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_citas);

        Bundle bundle = getIntent().getExtras();
        String cedulaUser = bundle.getString("userId");
        btnSalir=findViewById(R.id.exitBtn);
        cedulaId=findViewById(R.id.txtCedula);
        cedulaId.setText(cedulaUser);
        listaCitasRecycler = findViewById(R.id.CitasRecycle);
        listaCitasRecycler.setLayoutManager(new LinearLayoutManager(CitasActivity.this));
        obtenerCitas(cedulaUser);

        btnSalir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intentLogin = new Intent(getApplicationContext(), LoginActivity.class);
                startActivity(intentLogin);
            }
        });
    }


    private void obtenerCitas(String cedula) {

        Retrofit retrofit=new Retrofit.Builder().baseUrl("https://api-b87107-b84211.azurewebsites.net/")
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        HistorialMedicoApi historialAPI=retrofit.create(HistorialMedicoApi.class);
        Call<List<Citas>> call=historialAPI.citas(cedula);
        call.enqueue(new Callback<List<Citas>>() {

            @Override
            public void onResponse(Call<List<Citas>> call, Response<List<Citas>> response) {
                try {
                    if(response.isSuccessful()){
                        citas=response.body();
                        ListaCitasAdaptar adapter = new ListaCitasAdaptar(citas,CitasActivity.this);
                        listaCitasRecycler.setAdapter(adapter);

                    }
                }catch (Exception ex){
                    Toast.makeText(CitasActivity.this,ex.getMessage(),Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<Citas>> call, Throwable t) {
                Toast.makeText(CitasActivity.this,"Error de conexion",Toast.LENGTH_SHORT).show();
            }
        });

    }
}
