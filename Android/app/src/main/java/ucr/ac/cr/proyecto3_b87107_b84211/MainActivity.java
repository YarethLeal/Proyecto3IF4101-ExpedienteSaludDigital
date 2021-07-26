package ucr.ac.cr.proyecto3_b87107_b84211;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    TextView cedulaId;
    ImageButton btnSalir;
    ImageView IconDatos;
    ImageView IconCitas;
    ImageView IconVacunas;
    ImageView IconAlergias;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Bundle bundle = getIntent().getExtras();
        String cedulaUser = bundle.getString("userId");

        cedulaId=findViewById(R.id.usuarioId);
        btnSalir=findViewById(R.id.exitBtn);
        IconDatos=findViewById(R.id.datosIcon);
        IconCitas=findViewById(R.id.citaIcon);
        IconVacunas=findViewById(R.id.vacunaIcon);
        IconAlergias=findViewById(R.id.alergiaIcon);

        cedulaId.setText(cedulaUser);

        btnSalir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intentLogin = new Intent(getApplicationContext(), LoginActivity.class);
                startActivity(intentLogin);
            }
        });

        IconDatos.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intentDatos = new Intent(getApplicationContext(), DatosActivity.class);
                intentDatos.putExtra("userId",cedulaUser);
                startActivity(intentDatos);
            }
        });

        IconCitas.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intentCitas = new Intent(getApplicationContext(), CitasActivity.class);
                intentCitas.putExtra("userId",cedulaUser);
                startActivity(intentCitas);
            }
        });

        IconVacunas.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intentVacunas = new Intent(getApplicationContext(), VacunasActivity.class);
                intentVacunas.putExtra("userId",cedulaUser);
                startActivity(intentVacunas);
            }
        });

        IconAlergias.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intentAlergias = new Intent(getApplicationContext(), AlergiasActivity.class);
                intentAlergias.putExtra("userId",cedulaUser);
                startActivity(intentAlergias);
            }
        });
    }
}