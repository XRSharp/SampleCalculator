using XRSharp;
using XRSharp.Controls;
using XRSharp.Environments;

namespace Calculator3D;

public class LightFormerEnvironment2 : BasicEnvironment
{
    private readonly Canvas3D _canvas = new();

    public int Resolution { get; set; } = 256;

    public double RotationY { get; set; } = 0;

    public double Intensity { get; set; } = 1;

    public override void Init(Root3D root)
    {
        base.Init(root);

        // todo: create light formers from Objects
        //if (Objects.Count == 0)
        //    return;

        Interop.ExecuteJavaScriptVoid(@$"
const scene = {JsElement};
const virtualScene = new THREE.Scene();
virtualScene.rotation.y = {RotationY.ToRadiansInvariantString()};

const geometry = new THREE.RingGeometry(0, 1, 64);
const lights = new THREE.Group();
lights.rotation.set(-Math.PI / 3, 0, 1);

const light1 = new THREE.Mesh(geometry, createAreaLightMaterial(50));
light1.position.set(0, 5, -9);
light1.rotation.set(Math.PI / 2, 0, 0);
light1.scale.set(2, 2, 2);
lights.add(light1);

const light2 = new THREE.Mesh(geometry, createAreaLightMaterial(10));
light2.position.set(-5, 1, -1);
light2.rotation.set(0, Math.PI / 2, 0);
light2.scale.set(2, 2, 2);
lights.add(light2);

const light3 = new THREE.Mesh(geometry, createAreaLightMaterial(10));
light3.position.set(-5, -1, -1);
light3.rotation.set(0, Math.PI / 2, 0);
light3.scale.set(2, 2, 2);
lights.add(light3);

const light4 = new THREE.Mesh(geometry, createAreaLightMaterial(10));
light4.position.set(10, 1, 0);
light4.rotation.set(0, -Math.PI / 2, 0);
light4.scale.set(8, 8, 8);
lights.add(light4);

virtualScene.add(lights);

function createAreaLightMaterial(intensity) {{
  const material = new THREE.MeshBasicMaterial();
  material.color.multiplyScalar(intensity);
  material.color.multiplyScalar({this.Intensity.ToInvariantString()});
  return material;
}}

const fbo = new THREE.WebGLCubeRenderTarget({Resolution.ToInvariantString()});
fbo.texture.type = THREE.HalfFloatType;
const cubeCamera = new THREE.CubeCamera(1, 1000, fbo);

scene.object3D.environment = fbo.texture;
{(UseEnvironmentTextureAsBackground ? "scene.object3D.background = fbo.texture;" : "")}

cubeCamera.update(scene.renderer, virtualScene);
");
    }
}
